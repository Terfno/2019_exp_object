# 2019/06/21 プログラミング演習
<style>
    .c{
        text-align:center;
    }
</style>

## 目的
この演習においてはオブジェクト指向プログラミングにおける設計方針の基礎について学ぶ。

## 装置/ツール
* Visual Studio
* MacBook Pro

## 実験
### 問題8.1
> 実験書図8.2のプログラムを作成し、ソースコードと実行結果を報告しなさい。また、なぜgetInstanceメソッドを複数回呼び出してもインスタンスが変化しないのか説明しなさい。

ソースコードを図8.1.1に示す。
```cs
using System;

namespace chapter8_1
{
    public class Earth
    {
        private static Earth own = null;

        private string creator;

        private Earth()
        {
            Console.WriteLine("地球が作られました。");
        }

        public static Earth getInstance()
        {
            if(Earth.own == null)
            {
                Earth.own = new Earth();
                Earth.own.creator = "神";
            }

            return Earth.own;
        }

        public string getCreatorName()
        {
            return this.creator;
        }

        public void setCreatorName(string gname)
        {
            this.creator = gname;
        }
    }

    public class Terminal
    {
        public static void Main(string[] args)
        {
            Earth e1 = Earth.getInstance();
            Console.WriteLine("この星(e1)は誰が作ったのか?: {0}", e1.getCreatorName());

            Earth e2 = Earth.getInstance();
            Console.WriteLine("この星(e2)は誰が作ったのか?: {0}", e2.getCreatorName());

            e1.setCreatorName("俺");

            Console.WriteLine("この星(e1)は誰が作ったのか?: {0}", e1.getCreatorName());
            Console.WriteLine("この星(e2)は誰が作ったのか?: {0}", e2.getCreatorName());
        }
    }
}

```
<div class="c">図8.1.1 ソースコード</div>
<br>

実行結果を図8.1.2に示す。
![img](./img/8.1.2.png)
<div class="c">図8.1.2 実行結果</div>
<br>

Singletonパターンだから

### 問題8.2
> 実験書図8.4のプログラムを実装しスクリーンショットを報告しなさい。また、Factory Methodパターンに該当するクラスを列挙し、パターンのどのクラスに対応するか説明しあんさい。

実行結果を図8.2.1に示す。
![img](./img/8.2.1.png)
<div class="c">図8.2.1 実行結果</div>
<br>

Factory Methodパターンに対応するクラス
* FoodFactory
* CompanyA
* CompanyB
* Food
* Apple
* Orange

### 問題8.3
> Strategy パターンを使って、配列をソートするアルゴリズムを選択でき、加えてソート結果を表示するプログラムを作成しなさい。

ソースコードを図8.3.1に示す。
```cs
using System;

namespace chapter8_3
{
    public interface Sorting
    {
        // int型の配列を返すメソッド
        int[] Sort(int[] array);
    }

    // バブルソート
    public class Bubble : Sorting
    {
        public int[] Sort(int[] array)
        {
            Console.WriteLine("バブルソートをします。");
            int[] nums = array;
            int start, end, tmp;

            for (start = 1; start < nums.Length; start++)
            {
                for (end = nums.Length - 1; end >= start; end--)
                {
                    if (nums[end - 1] > nums[end])
                    {
                        tmp = nums[end - 1];
                        nums[end - 1] = nums[end];
                        nums[end] = tmp;
                    }
                }
            }

            return nums;
        }
    }

    // 選択ソート
    public class Selection : Sorting
    {
        public int[] Sort(int[] array)
        {
            Console.WriteLine("選択ソートをします。");
            int[] nums = array;
            int n = nums.Length;
            int minj = 0;

            for (int i = 0; i < n; i++)
            {
                minj = i;
                for (int j = minj; j < n; j++)
                {
                    if (nums[j] < nums[minj])
                    {
                        minj = j;
                    }
                }
                int tmp = nums[i];
                nums[i] = nums[minj];
                nums[minj] = tmp;
            }

            return nums;
        }
    }

    // ソートするアルゴリズムのコンテクスト
    public class Algo
    {
        private static Sorting _rithm;

        public int[] Sort(string type, int[] array)
        {
            if (type == "1")
            {
                _rithm = new Bubble();
            }
            else if(type == "2")
            {
                _rithm = new Selection();
            }
            else
            {
                Console.WriteLine("不正な入力です。ソートしませんでした。");
                return array;
            }

            return _rithm.Sort(array);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5] { 11, 5, 9, 100, 200 };
            Console.WriteLine("バブルソートなら1を、選択ソートなら2を入力してください。");
            string type = Console.ReadLine();

            Algo _algorithm = new Algo();
            Console.WriteLine("result:");

            int[] result = _algorithm.Sort(type, array);

            for (int i=0;i<result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}
```
<div class="c">図8.3.1 ソースコード</div>
<br>

実行結果を図8.3.2と図8.3.3に示す。
![img](./img/8.3.3.png)
<div class="c">図8.3.2 実行結果</div>
<br>

![img](./img/8.3.4.png)
<div class="c">図8.3.3 実行結果</div>
<br>

## 課題
### レポート課題8.1
> 今回紹介したデザインパターン以外で、GoFのデザインパターンを3つ調べてどのようなクラス設計になるのかクラス図を示し、利用すべき状況と利用によって生まれる利点を示しなさい。

### レポート課題8.2
> インターフェース分離の原則において、インターフェースはどのように設計すべきか、調べてまとめなさい。

### レポート課題8.3
> SOLID原則に基づいて、図8.4のプログラムの改良すべき点を説明しなさい。

