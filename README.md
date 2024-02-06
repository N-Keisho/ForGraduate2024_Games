# ForGraduate2024_Games

## 説明
2024年度卒業メンターに贈るゲームです.  
昨年のれふきっしーゲームズに，ミニゲーム同士をつなぐようなストーリーが追加されているイメージです．

### 関連ファイル
- [ゲーム作りのテーマと登場人物](https://nine-bike-e1b.notion.site/2024-657e3095a7494eb392f9486dcc95e6f9?pvs=4)
- [PM向けシート](https://docs.google.com/document/d/1V3t_zMQyf0RXn0IwO1Ikf_5Zodj7-u9Sxe1x3IXSSFU/edit)

### 参考ゲーム
- [きっしーれふゲームズ](https://github.com/wattah1002/ref-kissy-games)
- [きらりゲームズ](https://github.com/keichange/kirari-games)


## Unity 
- バージョン：2022.3.3f1 

## GitHubの使い方
### Github のアカウント作成とリポジトリの権限付与
1. github のアカウントを作る（まだ持ってない人のみ）
 - https://github.co.jp/
2. けーしょーにアカウントを送る（Pushができない場合）
 - Git リポジトリの管理者がわったーなので、順次権限を与えていきます
### コマンドラインの場合
```
// 1. 指定ディレクトリに移動.任意の場所です．
cd /Users/example/Desktop

// 2. データをダウンロード
git clone https://github.com/N-Keisho/ForGraduate2024_Games
```
### コマンドラインがよくわからないときは...
- わったーさんが"[きっしーれふゲームズ](https://github.com/wattah1002/ref-kissy-games)"のときにめちゃくちゃ丁寧な説明を作成されているので，適宜参照してください．
- [GitHub Desktop](https://desktop.github.com/)アプリが便利なのでご活用ください．
- 不明点があればけーしょーまでご連絡ください．

### branch ルール
基本的にシーンごとにブランチを切ります．
- master: 最終的にみんなのミニゲームを集めて統合するブランチ（開発段階ではノータッチ）
- Story: メインストーリーの開発ブランチ
- WattahGame: わったーのミニゲームの開発ブランチ
- SibaGame: しばのミニゲームの開発ブランチ
- KeichanGame: けいちゃんのミニゲームの開発ブランチ
- TukkunGame: つっくんのミニゲームのの開発ブランチ
- HiroppeGame: ひろっぺのミニゲームの開発ブランチ

## ルール
- 他の人のシーンを触らない．触る必要がある場合は，触っていそうな人に確認する．
- master ブランチで作業しない．自分のブランチで作業する．必要に応じて新しくブランチを切る．
- 自分のフォルダ内にスクリプトや素材を入れる
- ファイル名は「シーンを表す文字列_素材の名前」
 - 例：keichan_PlayerMove.cs
