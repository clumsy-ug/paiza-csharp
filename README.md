# paiza スキルチェック用 C# 環境

paiza の問題をローカルの VS Code で解くための作業環境です。
採点は paiza と同じ Mono のツールチェーン (`mcs` + `mono`) で行うので、
ローカルで `[OK]` なら paiza でも通ります。

## 前提

- .NET SDK 10
- Mono for Windows … `winget install Mono.Mono`

Mono が無くても動きますが、その場合は .NET でのビルド・実行にフォールバックし、
Mono に存在しない API を検出できません。

---

## 1 問解く流れ

### 0. 最初の 1 回だけ

リポジトリのルートを VS Code で開きます。

```powershell
code .
```

使うキーは 2 つです。どちらも VS Code の標準キーで、追加設定は要りません。

| キー | 動作 | 中身 |
| --- | --- | --- |
| `Ctrl+Shift+B` | 採点 | `Run Build Task`。採点タスクを既定のビルドタスクにしてある |
| `F5` | デバッグ実行 | `Start Debugging` |

押しやすいキーに変えたい場合は、`Ctrl+K Ctrl+S` → 右上の「キーボード ショートカットを開く (JSON)」で
自分の `keybindings.json` に足します (リポジトリには含めない個人設定)。

```json
{ "key": "ctrl+enter", "command": "workbench.action.tasks.build", "when": "editorTextFocus" }
```

採点はせず `Console.WriteLine` の結果だけを見たいときのために、
「実行: 出力だけ見る (判定なし)」というタスクも用意してあります。
`expected*.txt` との比較も `=== 問題名 ===` のような飾りも出さず、プログラムの出力をそのまま流します。

```json
{
  "key": "ctrl+alt+enter",
  "command": "workbench.action.tasks.runTask",
  "args": "実行: 出力だけ見る (判定なし)",
  "when": "editorTextFocus"
}
```

保存時の `mcs` チェックを有効にするため、自動タスクを許可します。

1. `Ctrl+Shift+P` でコマンドパレットを開く
2. `Tasks: Manage Automatic Tasks` と入力して選ぶ
3. `Allow Automatic Tasks` を選ぶ
4. `Ctrl+Shift+P` → `Developer: Reload Window` でウィンドウを再読み込み

以降はフォルダを開くだけで監視が動きます。

### 1. 問題フォルダを作る

1. `Ctrl+Shift+P` でコマンドパレットを開く
2. `Tasks: Run Task` と入力して選ぶ
3. 一覧から `new: 新しい問題フォルダを作る` を選ぶ
4. 問題名を入力する (例: `3つのデータの入力`)

`problems\004_3つのデータの入力\` が作られ、`Program.cs` / `input.txt` /
`expected.txt` / `input2.txt` / `expected2.txt` / `memo.md` が入った状態に
なります。番号は自動で振られます。

ターミナル派なら同じことを 1 行でできます。

```powershell
.\tools\New-Problem.ps1 3つのデータの入力
```

問題名の付け方:

- **日本語をそのまま使えます**。paiza の問題名をコピーして貼れば済みます
- 空白は `_` に置き換えられます (`N 行のデータ` → `N_行のデータ`)
- 半角コロンは全角の `：` に置き換えられます (`STEP: 1 文字の出力` → `STEP：1_文字の出力`)
- パスに使えない残りの文字 (`\ / * ? " < > |`) と Windows の予約名 (`CON` など) は弾かれます
- 先頭が `NNN_` でなければ連番が付きます。`3つのデータの入力` のように
  数字で始まる名前も「番号付き」とは見なさないので `004_3つのデータの入力` になります

間違えて作ってしまった問題を消すときは、フォルダを手で消さないでください。
`Paiza.slnx` に登録が残り、ソリューションのビルドが `error MSB3202` で失敗します。

1. `Ctrl+Shift+P` → `Tasks: Run Task` → `remove: 問題フォルダを削除する`
2. 問題名を入力する (部分一致でよい)
3. 消す中身が表示されるので `y` と入力する (`yes` でもよい。それ以外は中止)

手で消してしまった場合も、次に `New-Problem.ps1` か `Remove-Problem.ps1` を
実行した時点で `Paiza.slnx` の実体のない参照が自動で掃除されます。

```powershell
.\tools\Remove-Problem.ps1 005          # 確認あり
.\tools\Remove-Problem.ps1 005 -Force   # 確認なし
```

### 2. 入力例と出力例を貼る

paiza の問題文から、そのままコピーして貼り付けて保存します。

| paiza の項目 | 貼り先 |
| --- | --- |
| 入力例1 | `input.txt` |
| 出力例1 | `expected.txt` |
| 入力例2 | `input2.txt` |
| 出力例2 | `expected2.txt` |

`input2.txt` / `expected2.txt` は最初から空で用意されています。
入力例が 1 つしかない問題では空のままにしておけば、採点時にスキップされます。

入力例3がある問題では、ファイルを対で増やせば一度に全部判定されます。

```
input.txt   <-> expected.txt
input2.txt  <-> expected2.txt
input3.txt  <-> expected3.txt
```

### 3. Program.cs を書く

`Program.cs` を開いて `Main` の中を書きます。形は paiza のエディタの雛形と同じです。

```csharp
using System;

class Program
{
    static void Main()
    {
        // ここを書く
    }
}
```

入力の読み方 (空白区切り、N 行ループ、EOF まで読む) は `CHEATSHEET.md` にあります。

型を確認したいとき:

- 変数やメソッドにホバーすると型が出ます
- `var` の実際の型と引数名は常時インライン表示されます (inlay hints)
- `F12` で定義へジャンプ、`Ctrl+K Ctrl+I` でホバーを強制表示

保存すると 1 秒ほどで `mcs` が走り、paiza で通らない書き方は「問題」パネルに出ます。
Roslyn の赤波線が出ていなくても、ここにエラーが出たら paiza では落ちます。

### 4. 採点する

`Program.cs` をアクティブにした状態で `Ctrl+Shift+B`。

```
=== 004_sum_of_array ===
コンパイル: mcs / 実行: mono (paiza と同じ)

-- 入力: input.txt
-- 出力:
  8
  [OK] expected.txt と一致

すべて OK
```

`[NG]` なら何行目がどう違うかまで出ます。

```
  [NG] expected.txt と不一致
    1 行目: 期待 [12] / 実際 [8]
```

実行時例外なら Mono のスタックトレースがそのまま出ます。

出力が合わない理由が分からないときは `F5` でデバッグ実行します。
行番号の左をクリックしてブレークポイントを置くと、そこで止まって変数の中身を見られます
(`input.txt` が標準入力として流し込まれます)。
`F10` で次の行へ、`F11` で関数の中へ、`Shift+F5` で停止。

自分でキーボードから入力したい場合は、デバッグ構成を「キーボード入力」に切り替えて実行します。

> `F5` を押しても何も起きない場合は、`keybindings.json` で `Debug: Start Debugging` が
> 別のキーに割り当てられているか無効化されています。`Ctrl+K Ctrl+S` で確認してください。

### 5. paiza に提出する

`すべて OK` になったら `Program.cs` の中身を全部コピーします
(`using System;` から最後の `}` まで)。それを paiza のエディタに貼り付けて提出します。

`input.txt` を読み込む処理はこのファイルには入っていない (`shared\LocalRunner.cs` 側にある)
ので、消したり書き換えたりせずそのまま貼れます。

---

## 書ける C# の範囲

paiza の `mcs` は C# 7.0 相当で、しかも C# 7.0 の一部が未実装です。

### 使えるもの

`var` / LINQ / 文字列補間 `$"{x}"` / タプル `(int a, int b)` / `out var` /
桁区切り `1_000` / `is` 型パターン (`o is int n`) / `throw` 式 /
式形式メンバー `=>` / `?.` / `nameof`

### 使えないもの

| 分類 | 使えない機能 | エラー |
| --- | --- | --- |
| C# 7.0 のうち未実装 | ローカル関数 | `CS1525: Unexpected symbol '('` |
| C# 7.0 のうち未実装 | switch 文の型パターン (`case int n:`) | `CS0589: Internal compiler error ... type pattern matching` |
| C# 7.1 | `default` リテラル (`int x = default;`) | `CS1644` |
| C# 7.1 | `async Main` | `CS5001` |
| C# 7.2 | `in` 引数、`readonly struct`、`ref readonly` | `CS1644` |
| C# 7.3 | タプルの `==` / `!=` | `CS0019` |
| C# 8 | `switch` 式、`using var`、`??=`、範囲 `x[1..3]`、`is not` | `CS8370` |
| C# 9 | `record`、top-level statements、`new()` | `CS8370` など |
| C# 10 以降 | `global using`、生文字列 `"""`、コレクション式 `[1, 2, 3]` | `CS8370` など |
| API | `MaxBy` / `MinBy` / `Chunk` / `DistinctBy` など .NET 6 以降の LINQ | `CS1061` |

`switch` 文自体は使えます。使えないのは `case int n:` のような型パターンだけで、
`case 1:` のような定数パターンは問題ありません。

書き換え方は `CHEATSHEET.md` の「4. paiza で落ちる書き方」にあります。

## トラブルシューティング

| 症状 | 対処 |
| --- | --- |
| `CS1525: Unexpected symbol '('` | ローカル関数を使っている。通常のメソッドに出す |
| `CS0589: Internal compiler error ... type pattern matching` | `switch` の型パターンを使っている。`if` + `is` に書き換える |
| `CS1644` / `CS8370` | C# 7.1 以降の構文。上の表を見て書き換える |
| `CS1061 ... does not contain a definition for` | Mono に無い API。`CHEATSHEET.md` の代替を使う |
| 保存しても mcs のエラーが出ない | 自動タスクが未許可。「0. 最初の 1 回だけ」をやり直す |
| `Ctrl+Shift+B` / `F5` が別の問題を実行する | 対象の `Program.cs` をアクティブにしてから押す |
| `Ctrl+Shift+B` でタスク一覧が出る | 一覧から「採点: input.txt で実行して expected.txt と比較」を選ぶ |
| キーが効かない | `Ctrl+K Ctrl+S` で `Run Build Task` / `Debug: Start Debugging` の割り当てを確認する |
| キーボード入力が終われない | `Ctrl+Z` → `Enter` (EOF) |
| `error MSB3202: プロジェクト ファイル ... が見つかりませんでした` | 問題フォルダを手で消した。`Paiza.slnx` の該当 `<Project Path="..." />` 行を消す。`New-Problem.ps1` / `Remove-Problem.ps1` を実行しても自動で掃除される |
| VS Code が「Projects: ✕ N」とエラーを出す | 同上。`Paiza.slnx` に実体のない参照が残っている |
| 問題を削除できない (使用中) | 直前に別の操作でそのフォルダを触ったプロセスがまだハンドルを持っている。1 秒ほど待って再実行すれば通る。sln の登録は先に外れているのでビルドは壊れていない |
| `input.txt` を書き換えたのに反映されない | 保存されていない |
| 日本語が文字化けする | `input.txt` / `expected.txt` を UTF-8 で保存する |

## その他の操作

### ターミナルから採点する

```powershell
# mcs + mono で実行して expected.txt と比較 (問題名は部分一致でよい)
.\tools\Run-Problem.ps1 002

# 自分でキーボード入力する
.\tools\Run-Problem.ps1 002 -Interactive

# Mono ではなく .NET で実行する (Mono に無い API は検出されない)
.\tools\Run-Problem.ps1 002 -UseDotnet
```

### Visual Studio を使う

1. `Paiza.slnx` を開く (`.slnx` 対応は Visual Studio 17.14 以降)
2. ソリューションエクスプローラーで解きたい問題を右クリック → 「スタートアップ プロジェクトに設定」
3. `F5` で実行 (`input.txt` が自動で標準入力になる)

採点は VS Code 側か `Run-Problem.ps1` を使ってください
(Visual Studio の実行は .NET 側なので Mono との差が出ます)。

### mcs チェックを一時的に切る

どうしても新しい構文を試したい場合は、ビルド時のチェックを止められます。

```powershell
dotnet build .\problems\001_hello -p:PaizaMonoCheck=false
```

恒久的に変えるなら `Directory.Build.props` の `PaizaMonoCheck` と `LangVersion` を編集します。
ただし paiza が `mcs` / C# 7.0 であることは実測済みなので、
切ると paiza で落ちるコードが書けるようになります。

---

## 仕組み

役割を 2 つに分けています。

| 用途 | 使うもの | 理由 |
| --- | --- | --- |
| 編集・型表示・デバッグ実行 | .NET 10 + Roslyn | 型のホバー表示、ブレークポイント、変数の確認ができる |
| 構文チェック・採点 | Mono の `mcs` + `mono` | paiza と同じコンパイラ・同じランタイムで判定する |

Roslyn だけでは `LangVersion` で防げる範囲 (C# 7.1 以降の構文) しか検出できません。
`mcs` 固有の未実装機能や Mono に無い API は Roslyn が通してしまうので、
`mcs` を次の 2 か所で走らせて捕まえます。

1. 保存時 … 常駐タスク `watch: 保存時に mcs でチェック` が保存の約 1 秒後に `mcs` を実行し、
   結果を「問題」パネルに出す
2. ビルド時 … `Directory.Build.props` が `mcs` を通し、失敗するとビルドを止める
   (デバッグ実行も止まる)

そのうえで採点 (`Ctrl+Shift+B`) は `mcs` でコンパイルして `mono` で実行するので、
判定結果は paiza と同じです。

常駐タスクについて 2 点:

- コンパイル結果は `.mcs-cache\` に書きます。問題フォルダの中に書くと、
  そのフォルダを掴んだままになり `Remove-Problem.ps1` での削除が失敗します
- ウィンドウ再読み込みでタスクが二重に起動しないよう、同じフォルダに対しては
  1 プロセスだけが動くようにしてあります (2 つ目は起動直後に終了します)

## paiza 側の実行環境

| 項目 | 内容 |
| --- | --- |
| ランタイム | Mono JIT compiler 6.8.0.105 (.NET ではない) |
| コンパイラ | `mcs` (Mono C# compiler)。Roslyn の `csc` ではない |
| 言語仕様 | C# 7.0 |
| BCL | Mono 4.5 プロファイル (`/usr/lib/mono/4.5/mscorlib.dll`) |
| 実行時間 | 5.0 秒 |
| メモリ | 512 MB |

ランタイム・実行時間・メモリの出典は
[paiza 各言語のバージョン・環境情報](https://paiza.jp/guide/language)。
コンパイラ・言語仕様・BCL は、レベルアップ問題集の「提出前動作確認」で
実際にコードを流して確認した結果です。

| 試したコード | paiza の応答 |
| --- | --- |
| ローカル関数 `int Add(int a, int b) => a + b;` | `Main.cs(8,19): error CS1525: Unexpected symbol '('` |
| `int zero = default;` (C# 7.1) | `Main.cs(13,20): error CS1644: Feature 'default literal' cannot be used because it is not part of the C# 7.0 language specification` |
| `lines.MaxBy(s => s.Length)` | `Main.cs(14,33): error CS1061: ... does not contain a definition for 'MaxBy'` <br> `/usr/lib/mono/4.5/mscorlib.dll (Location of the symbol related to previous error)` |

ローカルの `mcs` (Mono 6.12) も同じエラーを同じ位置で出し、
参照先も `Mono\lib\mono\4.5\mscorlib.dll` で一致します。

## フォルダ構成

```
paiza-csharp\
├── Paiza.slnx                 ソリューション (XML 形式。1 プロジェクト 1 行)
├── Directory.Build.props      C# 7.0 固定と mcs チェックの設定 (全問題に適用)
├── README.md / CHEATSHEET.md
├── .mcs-cache\                保存時チェックの出力先 (git 管理外)
├── .vscode\                   デバッグ実行・タスク・inlay hints の設定
├── shared\
│   └── LocalRunner.cs         .NET でのデバッグ実行時に input.txt を標準入力に流す
├── templates\problem\         新しい問題のひな形
├── tools\
│   ├── _Solution.ps1          ソリューション操作の共通処理 (実体のない参照の掃除など)
│   ├── New-Problem.ps1        新しい問題フォルダを作る
│   ├── Remove-Problem.ps1     問題フォルダを削除しソリューションの登録も外す
│   ├── Run-Problem.ps1        mcs でコンパイルし mono で実行して expected.txt と比較
│   └── Watch-Mono.ps1         保存を監視して mcs のエラーを「問題」パネルに出す常駐タスク
└── problems\
    ├── 001_hello\             入力なし・出力だけ
    ├── 002_two_ints\          「3 5」-> 合計
    └── 003_n_lines\           N 行読んで合計
        ├── 003_n_lines.csproj
        ├── Program.cs         paiza に貼り付けるファイル
        ├── input.txt          問題の入力例
        ├── expected.txt       期待する出力例
        └── memo.md            問題 URL などのメモ
```

採点時も paiza と同様に `Program.cs` 単体をコンパイルしています。
