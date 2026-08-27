using System;

class Program
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(" ");
        int H = int.Parse(arr[0]);
        int W = int.Parse(arr[1]);
        int N = int.Parse(Console.ReadLine().Split(" ")[0]);

        int[,] matrix = new int[H, W];

        // 射撃訓練の枠を作る
        for (int i = 0; i < N; i++)
        {
            string[] line = Console.ReadLine().Split(" ");
            int row = int.Parse(line[0]) - 1;
            int column = int.Parse(line[1]) - 1;
            int hitScore = int.Parse(line[2]);
            int missScore = int.Parse(line[3]);

            matrix[row, column] = hitScore;
            
            // hitScore以外の8マスをmissScoreで埋める
            for (int r = row - 1; r <= row + 1; r++)
            {
                // hitScoreのマスの列が端の行だった場合、このrはmatrixにない行indexになってしまうので弾く
                if (r >= H || r < 0) continue;

                for (int c = column - 1; c <= column + 1; c++)
                {
                    // hitScoreのマスの列が端の列だった場合、このcはmatrixにない列indexになってしまうので弾く
                    if (c >= W || c < 0) continue;

                    // hitScoreのマスはすでに埋めてあるので飛ばす
                    if (r == row && c == column) continue;

                    matrix[r, c] = missScore;
                }
            }
        }

        int M = int.Parse(Console.ReadLine());

        // 射撃によりポイントを数える
        int answer = 0;
        for (int i = 0; i < M; i++)
        {
            string[] line2 = Console.ReadLine().Split(" ");
            int hitRow = int.Parse(line2[0]) - 1;
            int hitColumn = int.Parse(line2[1]) - 1;

            answer += matrix[hitRow, hitColumn];
        }

        Console.WriteLine(answer);
    }
}
