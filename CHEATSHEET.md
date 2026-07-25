# paiza C# チートシート (Mono / C# 7.0 相当)

掲載しているコードは Mono の `mcs` で実際にコンパイル・実行を確認済みなので、
paiza でそのまま通ります。

---

## 1. 入力の読み方

### 1行をそのまま受け取る

```csharp
string s = Console.ReadLine();
Console.WriteLine(s);
```

### 1行に整数が1つ

```csharp
int n = int.Parse(Console.ReadLine());
```

> 桁が大きいかもしれない合計値は `long` にしておくと安全（`int` は約 21 億まで）。

### 1行に空白区切りで2つ

```csharp
string[] parts = Console.ReadLine().Split(' ');
int a = int.Parse(parts[0]);
int b = int.Parse(parts[1]);
```

### 1行に空白区切りで複数（個数が可変）

```csharp
int[] nums = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
```

LINQ 版（`using System.Linq;` が必要）:

```csharp
int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
```

空白が連続していそうなときは:

```csharp
string[] parts = Console.ReadLine()
    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
```

### 1行目が個数 N、続く N 行がデータ

```csharp
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string line = Console.ReadLine();
    Console.WriteLine(line);
}
```

配列に溜めたいとき:

```csharp
int n = int.Parse(Console.ReadLine());
int[] a = new int[n];
for (int i = 0; i < n; i++)
{
    a[i] = int.Parse(Console.ReadLine());
}
```

### 1行目が「H W」、続く H 行に W 個の数（表・グリッド）

```csharp
string[] hw = Console.ReadLine().Split(' ');
int h = int.Parse(hw[0]);
int w = int.Parse(hw[1]);

int[][] grid = new int[h][];
for (int i = 0; i < h; i++)
{
    grid[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
}

Console.WriteLine(grid[0][0]);
```

### 行数が分からない（EOF まで読む）

```csharp
string line;
while ((line = Console.ReadLine()) != null)
{
    if (line.Length == 0) continue;
    Console.WriteLine(line);
}
```

### 入力を全部まとめて読む

```csharp
string all = Console.In.ReadToEnd();
string[] lines = all.Split('\n');
```

---

## 2. 出力の書き方

```csharp
Console.WriteLine(42);
Console.WriteLine("a" + 1);              // 文字列結合
Console.WriteLine($"{name} は {age} 歳"); // 文字列補間（C# 6 なのでOK）
Console.WriteLine("{0} {1}", a, b);      // 書式指定
Console.Write("改行なし");
```

### 配列を空白区切り／改行区切りで出す

```csharp
Console.WriteLine(string.Join(" ", nums));   // 1 2 3
Console.WriteLine(string.Join("\n", nums));  // 縦に並べる
```

### 小数の出力

```csharp
double x = 1.0 / 3.0;
Console.WriteLine(x.ToString("F3"));   // 0.333
```

### 出力が何万行もあるとき（遅さ対策）

`Console.WriteLine` を大量に呼ぶと遅いので、まとめて出す:

```csharp
using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 200000; i++)
        {
            sb.Append(i).Append('\n');
        }
        Console.Write(sb.ToString());
    }
}
```

### 入力が何万行もあるとき

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, 1 << 16);
        Console.SetIn(sr);

        // 以降は普通に Console.ReadLine() でOK（速くなる）
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(n);
    }
}
```

---

## 3. よく使う処理

```csharp
// ソート
Array.Sort(a);                      // 昇順
Array.Sort(a); Array.Reverse(a);    // 降順

// 最大・最小・合計（using System.Linq;）
int max = a.Max();
int min = a.Min();
long sum = a.Sum(x => (long)x);     // オーバーフロー対策で long に

// 条件で数える・絞る
int cnt = a.Count(x => x % 2 == 0);
int[] evens = a.Where(x => x % 2 == 0).ToArray();

// リスト
List<int> list = new List<int>();
list.Add(5);
list.Sort();

// 辞書（数え上げ）
Dictionary<string, int> dic = new Dictionary<string, int>();
if (!dic.ContainsKey(key)) dic[key] = 0;
dic[key]++;

// 文字列
s.Length; s[0]; s.Substring(1, 3); s.ToUpper(); s.Contains("a");
s.IndexOf("a"); s.Replace("a", "b"); s.Trim();
char[] cs = s.ToCharArray();

// 文字と数字
int d = s[0] - '0';        // '7' → 7
char c = (char)('a' + 1);  // 'b'

// 数値
Math.Abs(x); Math.Max(a, b); Math.Min(a, b); Math.Pow(2, 10);
(int)Math.Sqrt(n);         // 整数の平方根は誤差に注意
```

### タプルで2つ返す（C# 7.0 なのでOK）

```csharp
static (int min, int max) MinMax(int[] a)
{
    int lo = a[0], hi = a[0];
    foreach (int x in a) { if (x < lo) lo = x; if (x > hi) hi = x; }
    return (lo, hi);
}

// 呼び出し側
var r = MinMax(nums);
Console.WriteLine(r.min + " " + r.max);
```

---

## 4. paiza で落ちる書き方

### 構文 (ローカルでもビルドエラーになる)

```csharp
// ✗ record（C# 9）
public record Point(int X, int Y);
// ○ 普通のクラス
public class Point { public int X; public int Y; }

// ✗ top-level statements（C# 9）
Console.WriteLine("hi");
// ○ class + Main で囲む
class Program { static void Main() { Console.WriteLine("hi"); } }

// ✗ switch 式（C# 8）
string s = x switch { 1 => "one", _ => "other" };
// ○ switch 文
string s;
switch (x) { case 1: s = "one"; break; default: s = "other"; break; }

// ✗ new()（C# 9）           ○ new List<int>()
List<int> list = new();

// ✗ using var（C# 8）       ○ using (var sr = ...) { }
using var sr = new StreamReader(path);

// ✗ ??=（C# 8）             ○ if (s == null) s = "x";
s ??= "x";

// ✗ コレクション式（C# 12）  ○ new int[] { 1, 2, 3 }
int[] a = [1, 2, 3];
```

### mcs が未実装のもの（C# 7.0 の機能なのに通らない）

Mono のコンパイラ `mcs` は C# 7.0 相当だが、以下は実装されていない。
Roslyn (Visual Studio / VS Code の赤波線) は通してしまうので要注意。

```csharp
// ✗ ローカル関数 -> CS1525: Unexpected symbol '('
static void Main()
{
    int Add(int a, int b) => a + b;
    Console.WriteLine(Add(1, 2));
}
// ○ 普通の static メソッドに出す
static int Add(int a, int b) { return a + b; }
static void Main() { Console.WriteLine(Add(1, 2)); }
```

```csharp
// ✗ switch 文の型パターン -> CS0589: Internal compiler error ... type pattern matching
switch (o)
{
    case int n: Console.WriteLine(n); break;
}
// ○ if + is 型パターンに書き換える（is の方は使える）
if (o is int n) { Console.WriteLine(n); }
```

`case 1:` のような定数パターンの `switch` 文は問題なく使える。

### C# 7.1 / 7.2 / 7.3 の機能

```csharp
// ✗ default リテラル（7.1）   ○ int x = default(int);
int x = default;

// ✗ async Main（7.1）         ○ 同期の static void Main()
static async Task Main() { }

// ✗ in 引数（7.2）            ○ 普通の値引数
static int F(in int x) => x + 1;

// ✗ readonly struct（7.2）    ○ 普通の struct
readonly struct P { }

// ✗ タプルの ==（7.3）        ○ 要素ごとに比較
if (a == b) { }
if (a.Item1 == b.Item1 && a.Item2 == b.Item2) { }
```

### Mono に無い API

.NET には存在するが Mono には無いもの。
保存時のチェックや採点（`Ctrl+Enter`）で `CS1061` として落ちる。

| 使わない | 代わりにこう書く |
| --- | --- |
| `a.MaxBy(x => x.Key)` | `a.OrderByDescending(x => x.Key).First()` |
| `a.MinBy(...)` | `a.OrderBy(...).First()` |
| `a.Chunk(3)` | 自分で `for` を回す |
| `a.DistinctBy(x => x.Id)` | `a.GroupBy(x => x.Id).Select(g => g.First())` |
| `s.Split("ab")`（文字列1引数） | `s.Split(new string[] { "ab" }, StringSplitOptions.None)` |
| `StringSplitOptions.TrimEntries` | `Split` した後に `.Trim()` |
| `Enumerable.Range(..).ToHashSet()` | `new HashSet<int>(Enumerable.Range(..))` |

---

## 5. 制限（paiza）

- 実行時間 **5.0 秒** / メモリ **512 MB**
- ざっくり `for` ループ 1 億回で数秒かかります
  → N が 10 万以上なら二重ループ（O(N²)）は間に合わないことが多い
