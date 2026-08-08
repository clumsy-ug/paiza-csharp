# 問題メモ

- 問題URL:
- ランク:
- 制限: 5.0 秒 / 512 MB

# デバッグ用コード

```cs
// スタンプの表
for (int i = 0; i < stamps.Count; i++)
{
    Console.WriteLine($"---stamps[{i}]---");
    char[,] stamp = stamps[i];
    for (int j = 0; j < H; j++)
    {
        for (int k = 0; k < W; k++)
        {
            Console.Write(stamp[j, k]);
            if (k == W - 1)
            {
                Console.WriteLine();
            } else
            {
                Console.Write(" ");
            }
        }
    }
}

// スタンプの貼り方
for (int i = 0; i < R; i++)
{
    for (int j = 0; j < C; j++)
    {
        Console.Write(stampPlan[i, j]);
        if (j == C - 1)
        {
            Console.WriteLine();
        } else
        {
            Console.Write(" ");
        }
    }
}
```

## 入力

```
```

## 出力

```
```

## 気づいたこと
