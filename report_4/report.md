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



## 課題
### 課題4.1
> ソースコード中の2つの関数SwitchFlagとFuncArraysに対して、結合度の段階として何結合となっているか説明しなさい。
> また、結合度を下げるための提案をしなさい。

SwitchFlagがFuncArray内のflagを制御しているため、制御結合である。
結合度を下げる方法として