// ローカル実行専用のヘルパー。paiza には提出しない。
//
// 問題フォルダにある input1.txt / input2.txt / ... を順に標準入力に差し替えて、
// テストケースごとに Main を呼ぶ。出力には
//   --- input1.txt / expected1.txt ---
// のような見出しを付けるので、F5 (デバッグ実行) 1 回で全ケースの出力を見られる。
// これにより Program.cs 側はローカル専用のコードを持たず、そのまま paiza に提出できる。
//
// 対象になるテストケース: input*.txt のうち、入力か期待出力 (expected*.txt) のどちらかに
// 中身があるもの。両方とも空の対は New-Problem が用意した未使用の枠なので飛ばす
// (Run-Problem.ps1 の採点と同じ規則)。どれも空なら 1 回だけキーボード入力で実行する。
//
// 注意: 同じプロセスで Main を続けて呼ぶので、static フィールドは前のケースの値を引き継ぐ。
//       (paiza では 1 ケースごとに別プロセスなので、この差で結果が変わることがある)
//
// 環境変数:
//   PAIZA_INPUT=input2.txt   指定した入力ファイルだけで 1 回実行する
//   PAIZA_STDIN=console      input*.txt を使わずキーボード入力で 1 回実行する
//   PAIZA_STDIN=pipe         呼び出し側が標準入力を流し込む (Run-Problem.ps1 用)
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

internal static class LocalRunner
{
    private sealed class TestCase
    {
        public string InputPath;     // 入力が空なら null (空の標準入力で実行する)
        public string InputName;     // input2.txt
        public string ExpectedName;  // expected2.txt
    }

    public static int Main(string[] args)
    {
        TrySetUtf8Console();

        MethodInfo entry = FindSolutionEntryPoint();
        if (entry == null)
        {
            Console.Error.WriteLine("[local] Main メソッドが見つかりません。");
            Console.Error.WriteLine("        Program.cs に  class Program { static void Main() { ... } }  を用意してください。");
            return 1;
        }

        string mode = Environment.GetEnvironmentVariable("PAIZA_STDIN");

        // pipe: 呼び出し側 (Run-Problem.ps1) が標準入力を流し込むので、そのまま 1 回呼ぶ
        if (Is(mode, "pipe"))
            return Run(entry, args);

        // console: キーボード入力で 1 回
        if (Is(mode, "console"))
        {
            Console.Error.WriteLine("[local] キーボード入力を待ちます (入力終了: Ctrl+Z → Enter)");
            return Run(entry, args);
        }

        string problemDir = FindProblemDir();

        // PAIZA_INPUT: 指定したファイルだけで 1 回
        string explicitPath = Environment.GetEnvironmentVariable("PAIZA_INPUT");
        if (!string.IsNullOrEmpty(explicitPath))
        {
            string full = Path.IsPathRooted(explicitPath) || problemDir == null
                ? explicitPath
                : Path.Combine(problemDir, explicitPath);
            if (!File.Exists(full))
            {
                Console.Error.WriteLine("[local] PAIZA_INPUT のファイルが見つかりません: " + full);
                return 1;
            }
            Console.Error.WriteLine("[local] 標準入力 <- " + full);
            return RunWithInput(entry, args, full);
        }

        // 通常 (F5): 使っているテストケースを全部、順に実行する
        List<TestCase> cases = FindTestCases(problemDir);
        if (cases.Count == 0)
        {
            Console.Error.WriteLine("[local] input*.txt / expected*.txt がどれも空なのでキーボード入力を待ちます (入力終了: Ctrl+Z → Enter)");
            return Run(entry, args);
        }

        // 見出しは解答側が Console.SetOut しても届くよう、元の標準出力に書く
        TextWriter stdout = Console.Out;
        int exitCode = 0;
        for (int i = 0; i < cases.Count; i++)
        {
            TestCase tc = cases[i];
            if (i > 0) stdout.WriteLine();
            stdout.WriteLine("--- " + tc.InputName + " / " + tc.ExpectedName + " ---");
            stdout.Flush();

            int code = RunWithInput(entry, args, tc.InputPath);
            if (code != 0) exitCode = code;
        }
        return exitCode;
    }

    private static bool Is(string value, string expected)
    {
        return string.Equals(value, expected, StringComparison.OrdinalIgnoreCase);
    }

    // ---- テストケースの探索 -------------------------------------------------

    // 出力先 (bin\Debug\net10.0) から上に辿って、.csproj のあるフォルダ = 問題フォルダを探す
    private static string FindProblemDir()
    {
        DirectoryInfo dir = new DirectoryInfo(AppContext.BaseDirectory);
        for (int i = 0; i < 6 && dir != null; i++, dir = dir.Parent)
        {
            if (dir.GetFiles("*.csproj").Length > 0)
                return dir.FullName;
        }
        return null;
    }

    private static List<TestCase> FindTestCases(string problemDir)
    {
        List<TestCase> cases = new List<TestCase>();
        if (problemDir == null) return cases;

        foreach (string path in Directory.GetFiles(problemDir, "input*.txt"))
        {
            string name         = Path.GetFileName(path);
            string suffix       = Path.GetFileNameWithoutExtension(name).Substring("input".Length);
            string expectedName = "expected" + suffix + ".txt";

            bool inputBlank = IsBlank(path);
            // 入力も期待出力も空 = 未使用の枠 (Run-Problem.ps1 と同じ規則で飛ばす)
            if (inputBlank && IsBlank(Path.Combine(problemDir, expectedName))) continue;

            TestCase tc = new TestCase();
            tc.InputPath    = inputBlank ? null : path;
            tc.InputName    = name;
            tc.ExpectedName = expectedName;
            cases.Add(tc);
        }

        // input1.txt, input2.txt, input3.txt, ... の順。
        // 文字列順だと input10.txt が input2.txt の前に来るので番号で並べる
        cases.Sort((a, b) =>
        {
            int byNumber = CaseNumber(a.InputName).CompareTo(CaseNumber(b.InputName));
            return byNumber != 0 ? byNumber : string.CompareOrdinal(a.InputName, b.InputName);
        });
        return cases;
    }

    // input1.txt -> 1, input2.txt -> 2, input3.txt -> 3, それ以外 -> 末尾
    private static int CaseNumber(string inputName)
    {
        string suffix = Path.GetFileNameWithoutExtension(inputName).Substring("input".Length);
        int n;
        return int.TryParse(suffix, out n) ? n : int.MaxValue;
    }

    // 無い、または空白しかないファイルを「空」とみなす
    private static bool IsBlank(string path)
    {
        try
        {
            if (!File.Exists(path)) return true;
            return string.IsNullOrWhiteSpace(File.ReadAllText(path));
        }
        catch
        {
            return true;
        }
    }

    // ---- 解答側の Main を探して呼ぶ -----------------------------------------

    // クラス名が Program 以外でも、Main が private でも動くようリフレクションで呼ぶ
    private static MethodInfo FindSolutionEntryPoint()
    {
        Assembly asm = typeof(LocalRunner).Assembly;
        MethodInfo fallback = null;

        foreach (Type t in asm.GetTypes())
        {
            if (t == typeof(LocalRunner)) continue;

            MethodInfo m = GetMain(t, new Type[] { typeof(string[]) }) ?? GetMain(t, Type.EmptyTypes);
            if (m == null) continue;

            if (t.Name == "Program") return m;
            if (fallback == null) fallback = m;
        }
        return fallback;
    }

    private static MethodInfo GetMain(Type t, Type[] signature)
    {
        return t.GetMethod(
            "Main",
            BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
            null,
            signature,
            null);
    }

    // 標準入力を inputPath (null なら空) に差し替えて Main を 1 回呼ぶ
    private static int RunWithInput(MethodInfo entry, string[] args, string inputPath)
    {
        TextReader reader = inputPath == null
            ? (TextReader)new StringReader("")
            : new StreamReader(inputPath, new UTF8Encoding(false));
        try
        {
            Console.SetIn(reader);
            return Run(entry, args);
        }
        finally
        {
            reader.Dispose();
        }
    }

    // 解答側の Main を 1 回呼ぶ。戻り値は終了コード。
    private static int Run(MethodInfo entry, string[] args)
    {
        object[] parameters = entry.GetParameters().Length == 0
            ? new object[0]
            : new object[] { args };

        try
        {
            object result = entry.Invoke(null, parameters);
            return result is int ? (int)result : 0;
        }
        catch (TargetInvocationException ex) when (ex.InnerException != null)
        {
            // 解答コードが投げた例外。スタックトレースを見せたうえで、次のケースに進めるよう 1 を返す
            // (デバッガを付けていれば、ここに来る前に投げた行で止まる)
            Console.Out.Flush();
            Console.Error.WriteLine("[local] 実行時エラー: " + ex.InnerException);
            return 1;
        }
        finally
        {
            // 解答側が Console.SetOut でバッファ付きの Writer に差し替えていても出力を確定させる
            Console.Out.Flush();
        }
    }

    private static void TrySetUtf8Console()
    {
        try { Console.OutputEncoding = new UTF8Encoding(false); }
        catch { /* リダイレクト中などで失敗しても無視 */ }
    }
}
