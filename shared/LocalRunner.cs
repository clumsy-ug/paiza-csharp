// ローカル実行専用のヘルパー。paiza には提出しない。
//
// 問題フォルダにある input.txt を標準入力に差し替えてから Main を呼ぶ。
// これにより Program.cs 側はローカル専用のコードを持たず、
// そのまま paiza に提出できる状態を保てる。
//
// 環境変数:
//   PAIZA_INPUT=input2.txt   読み込む入力ファイルを変える
//   PAIZA_STDIN=console      input.txt を使わずキーボード入力にする
//   PAIZA_STDIN=pipe         呼び出し側が標準入力を流し込む (Run-Problem.ps1 用)
using System;
using System.IO;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;

internal static class LocalRunner
{
    public static int Main(string[] args)
    {
        TrySetUtf8Console();

        // pipe のときは呼び出し側が標準入力を渡すので、こちらでは何もしない
        bool piped = string.Equals(Environment.GetEnvironmentVariable("PAIZA_STDIN"), "pipe",
                                   StringComparison.OrdinalIgnoreCase);

        string inputPath = piped ? null : ResolveInputFile();
        if (inputPath != null)
        {
            Console.Error.WriteLine("[local] 標準入力 <- " + inputPath);
            Console.SetIn(new StreamReader(inputPath, new UTF8Encoding(false)));
        }
        else if (!piped)
        {
            Console.Error.WriteLine("[local] input.txt が見つからない/空なのでキーボード入力を待ちます (入力終了: Ctrl+Z → Enter)");
        }

        MethodInfo entry = FindSolutionEntryPoint();
        if (entry == null)
        {
            Console.Error.WriteLine("[local] Main メソッドが見つかりません。");
            Console.Error.WriteLine("        Program.cs に  class Program { static void Main() { ... } }  を用意してください。");
            return 1;
        }

        object result = Invoke(entry, args);
        return result is int ? (int)result : 0;
    }

    // ---- 入力ファイルの探索 -------------------------------------------------

    private static string ResolveInputFile()
    {
        string mode = Environment.GetEnvironmentVariable("PAIZA_STDIN");
        if (string.Equals(mode, "console", StringComparison.OrdinalIgnoreCase))
            return null;

        string explicitPath = Environment.GetEnvironmentVariable("PAIZA_INPUT");
        if (!string.IsNullOrEmpty(explicitPath))
        {
            string full = Path.IsPathRooted(explicitPath)
                ? explicitPath
                : FindNearProject(explicitPath);
            return HasContent(full) ? full : null;
        }

        return FindNearProject("input.txt");
    }

    // 出力先 (bin\Debug\net10.0) から上に辿って、問題フォルダにあるファイルを探す
    private static string FindNearProject(string fileName)
    {
        DirectoryInfo dir = new DirectoryInfo(AppContext.BaseDirectory);
        for (int i = 0; i < 6 && dir != null; i++, dir = dir.Parent)
        {
            string candidate = Path.Combine(dir.FullName, fileName);
            if (HasContent(candidate))
                return candidate;

            // 無関係な input.txt を拾わないよう、問題フォルダより上には行かない
            if (Directory.GetFiles(dir.FullName, "*.csproj").Length > 0)
                break;
        }
        return null;
    }

    private static bool HasContent(string path)
    {
        try
        {
            if (path == null || !File.Exists(path)) return false;
            return new FileInfo(path).Length > 0;
        }
        catch
        {
            return false;
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

    private static object Invoke(MethodInfo entry, string[] args)
    {
        object[] parameters = entry.GetParameters().Length == 0
            ? new object[0]
            : new object[] { args };

        try
        {
            return entry.Invoke(null, parameters);
        }
        catch (TargetInvocationException ex) when (ex.InnerException != null)
        {
            // 解答コードが投げた例外のスタックトレースをそのまま見せる
            ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            throw;
        }
    }

    private static void TrySetUtf8Console()
    {
        try { Console.OutputEncoding = new UTF8Encoding(false); }
        catch { /* リダイレクト中などで失敗しても無視 */ }
    }
}
