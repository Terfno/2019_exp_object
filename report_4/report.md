# 2019/05/10 プログラミング演習
<style>
    .center{
        text-align:center;
    }
</style>

## 目的
この演習においてはモジュールの結合度・凝集度について触れる。

## 装置/ツール
* Visual Studio
* MacBook Pro

## 実験
### 問題4.1
> 2つの配列の共通集合を表示するvoid IntersectAndPrint(int [], int[])関数を実験書図4.2と図4.3の実行結果を元に作成し、ソースコードを示しなさい。

IntersectAndPrint関数を図4.1に示す。
```cs
static void IntersectAndPrint (int[] a, int[] b)
{
    int[] dup = new int[a.Length];

    int dupCnt = 0;

    for(int j = 0; j < a.Length; j++)
    {
        if (Containe(dup, dupCnt, a[j]))
        {
            continue;
        }

        for (int i = 0; i < b.Length; i++)
        {
            if (a[j] == b[i])
            {
                dup[dupCnt] = a[j];
                dupCnt++;
            }
        }
    }

    for (int i = 0; i < dupCnt; i++)
    {
        Console.Write(dup[i] + " ");
    }
}
```
<div class="center">図4.1 IntersectAndPrint関数</div>

## 課題
### 課題4.1
> ソースコード中の2つの関数SwitchFlagとFuncArraysに対して、結合度の段階として何結合となっているか説明しなさい。
> また、結合度を下げるための提案をしなさい。

SwitchFlagがFuncArray内のflagを制御しているため、制御結合である。
結合度を下げる方法として