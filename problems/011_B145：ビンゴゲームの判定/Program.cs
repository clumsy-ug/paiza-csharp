using System;

class Program
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(" ");
        int N = int.Parse(arr[0]);  // N * N マス。真ん中が確定で0で最初から穴空いてる
        int K = int.Parse(arr[1]);  // K回抽選

        int[,] matrix = new int[N, N];

        // N * N のループ（ビンゴ表のマス数）
        for (int i = 0; i < N; i++)
        {
            string[] line = Console.ReadLine().Split(" ");

            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = int.Parse(line[j]);
            }
        }
        
        string[] lotteryNumbers = Console.ReadLine().Split(" ");
        // K のループ（抽選回数）
        for (int i = 0; i < K; i++)
        {
            int lotteryNumber = int.Parse(lotteryNumbers[i]);
            
            // N * N のループ（ビンゴ表の中に一致する数字があるか判定）
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        // 条件から 0 ≦ b_{i,j} なので、負数を入れておけばそのマスは 一致した or 0ですでに開いている と見なせる
                        matrix[row, col] = -1;

                        // 0を見つけてもまだlotteryNumberがあるか探すべきなので、gotoせずに次の列へ
                        continue;
                    }

                    if (matrix[row, col] == lotteryNumber)
                    {
                        matrix[row, col] = -1;
                        goto NextLottery;
                    }
                }
            }
            NextLottery:;
        }
        
        int answer = 0;

        // N行のビンゴチェック
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                // 開いていないマスが見つかった時点で次の行へ
                if (matrix[i, j] >= 0) break;

                // 最後の列までbreak無し = ずっと-1（開いたマス） = この行はビンゴ
                if (j == N - 1) answer++;
            }
        }

        // N列のビンゴチェック
        for (int j = 0; j < N; j++)
        {
            for (int i = 0; i < N; i++)
            {
                // 開いていないマスが見つかった時点で次の列へ
                if (matrix[i, j] >= 0) break;

                // 最後の行までbreak無し = ずっと-1（開いたマス）= この列はビンゴ
                if (i == N - 1) answer++;
            }
        }

        // ななめ（左上から右下方向）のビンゴチェック
        for (int i = 0; i < N; i++)
        {
            // 開いていないマスが見つかった時点で終了
            if (matrix[i, i] >= 0) break;

            if (i == N - 1) answer++;
        }

        // ななめ（右上から左下方向）のビンゴチェック
        int diagonalRow = 0;
        int diagonalCol = N - 1;
        while (diagonalCol >= 0)
        {
            // 開いていないマスが見つかった時点で終了
            if (matrix[diagonalRow, diagonalCol] != -1) break;

            // 最後の列（＝最後の行）まできている、かつ前段でこのマスも-1であることが保証されている = ビンゴ
            if (diagonalCol == 0) answer++;

            diagonalRow++;
            diagonalCol--;
        }

        Console.WriteLine(answer);
    }
}
