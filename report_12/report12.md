# 2019/07/26 実験実習
<style>
    .c{
        text-align:center;
    }
</style>


## 目的
この演習においてはオブジェクト指向プログラミングの理解を深める。

## 装置/ツール
* Visual Studio
* Windows 10 Pro

## 実験
### 問題12.1
> 実験書の図12.2から図12.10を既存のプロジェクトに追加して、実行結果の説明とスクリーンショットを報告しなさい。

実行結果を図12.1.1に示す。
![img](https://i.imgur.com/lu8meWS.png)
<div class="c">図12.1.1 実行結果</div>

自機と敵機のそれぞれの本体と弾丸に当たり判定が実装されている。

### 問題12.2
> プログラムの機能を独自に改変し、改変したソースコードを報告しなさい。

実行結果を図12.2.1に示す。
![img](https://i.imgur.com/873M4sr.png)
<div class="c">図12.2.1 実行結果</div>
自機と敵機の弾丸の色と大きさが変更されている。

改変した`EnemyShot.cs`の改変箇所を図12.2.2に示す。
```cs
this.shotBrush = new SolidColorBrush(this.d2dDeviceContext, Color.Red);
```
<div class="c">図12.2.2 弾丸の色変更</div>

改変した`PlayerShot.cs`の改変箇所を図12.2.3に示す。
```cs
this.shotBrush = new SolidColorBrush(this.d2dDeviceContext, Color.Green);
```
<div class="c">図12.2.3 弾丸の色変更</div>

## 課題
### レポート課題12.1
> クラス図を作りなさい。

クラス図を図12.3に示す。

<!-- 
```graphviz
digraph obj{
    node[shape=record]
    rankdir="BT"
    
    App[label="{
    App||
    -Main()\n
    ¯¯¯¯¯¯¯¯¯
    }"]
    
    FrameworkViewSource[label="{
    FrameworkViewSource||
    +CreateView():IFrameworkView
    }"]
    
    FrameworkView[label="{
    FrameworkView|
    -d2dDeviceContext:SharpDX.Direct2D1.DeviceContext\n
    -d2dTarget:Bitmap1\n
    -swapChain:SwapChain1\n
    -mWindow:CoreWindow\n
    -tFighterPath:TransformedGeometry\n
    -fighterBrush:SolidColorBrush\n
    -fighterDisplay:Fighter\n
    -displayList:List＜IDrawable＞\n
    -playerShotManager:PlayerShotManager\n
    -enemyDisplay:SimpleEnemy\n
    -updateList:List＜IUpdatable＞\n
    -targetManager:RectTargetManager\n
    -enemyShotManager:EnemyShotManager\n|
    +Initialize(applicationView:CoreApplicationView):void\n
    OnActivated(applicationView:CoreApplicationView, args:IActivatedEventArgs):void\n
    CreateDeviceResources():void\n
    +SetWindow(window:CoreWindow):void\n
    +Load(entryPoint:string):void\n
    +Run():void\n
    +Uninitialize():void
    }"]
    
    EnemyShot[label="{
    EnemyShot|
    -shotBrush:SolidColorBrush\n
    -targetX:int\n
    -targetY:int\n
    -rad:double\n
    -dSpeedX:float\n
    -dSpeedY:float\n
    -isVisible:bool\n
    -player:IMovableRectTarget\n
    -speed:int\n
    -debugBrush:SolidColorBrush\n
    -INNER_DIFF:float = 5f\n
    -MAX_X:float = 5f\n
    -MAX_Y:float = 5f\n|
    +EnemyShot(ctx:DeviceContext, player:IMovableRectTarget, speed:int)\n
    +Crash():void\n
    +Draw():void\n
    +IsFinished():bool\n
    +SetPosition(y:int, x:int):void\n
    +GetNorthEastX():int\n
    +GetNorthEastY():int\n
    +GetSouthWestX():int\n
    +GetSouthWestY():int\n
    +IsHitted(c:IRectBounds):bool\n
    +IsCrashing():bool\n
    +MoveNext():void\n
    +GetCenterX():int\n
    +GetCenterY():int\n
    }"]
    
    EnemyShotManager[label="{
    EnemyShotManager|
    -context:DeviceContext\n
    -player:IMovableRectTarget\n
    -enemies:RectTargetManager\n
    -shotList:List＜IMovableRectTarget＞\n
    -rng:Random\n
    -drawList:List＜IMovableRectTarget＞\n
    -SHOT_NUM_MAX:const int = 50\n
    -SHOT_SPEED:const int = -3\n|
    +EnemyShotManager(ctx:DeviceContext, \nenemyManager:RectTargetManager, player:IMovableRectTarget)\n
    -Initialize():void\n
    -SetFire():void\n
    +Update():void\n
    +IsHitted(c:IRectBounds):bool\n
    +Draw():void
    }"]
    
    Fighter[label="{
    Fighter|
    - d2dDeviceContext:DeviceContext\n
    - d2dDevice:Device\n
    - fighterPat:TransformedGeometry\n
    - fighterBrush:SolidColorBrush\n
    - debugBrush:SolidColorBrush\n
    - x:int\n
    - y:int\n
    - firstPoint:Vector2\n
    - secondPoint:Vector2\n
    - thirdPoint:Vector2\n
    - shotManager:PlayerShotManager\n
    - isVisible:bool\n
    - MAX_X:const float = 50f\n
    - MAX_Y:const float = 50f\n|
    +Fighter(ctx:DeviceContext, manager:PlayerShotManager)\n
    -Initialize():void\n
    +Draw():void\n
    +Move(dy:int, dx:ing):void\n
    +SetPosition(y:int, x:int):void\n
    +IsMovable():bool\n
    +Fire():void\n
    +Movenext():void\n
    +GetCenterX():void\n
    +GetCenterY():void\n
    +IsHitted(c:IRectBounds):bool\n
    +Crash():void\n
    +IsFinished():bool\n
    +IsCrashing():bool\n
    +GetNorthEastX():int\n
    +GetNorthEastY():int\n
    +GetSouthWestX():int\n
    +GetSouthWestY():int\n
    }"]
    
    ICrashable[label="{
    ＜＜interface＞＞\n
    ICrashable||
    Crash():void\n
    IsFinished():bool\n
    IsCrashing():bool\n
    }"]
    
    IDrawable[label="{
    ＜＜interface＞＞\n
    IDrawable||
    Draw():void
    }"]
    
    IFirable[label="{
    ＜＜interface＞＞\n
    IFirable||
    Fire():void
    }"]
    
    IHittable[label="{
    ＜＜interface＞＞\n
    IHittable||
    IsHitted(c:IRectBounds):bool
    }"]
    
    IMovable[label="{
    ＜＜interface＞＞\n
    IMovable||
    Move(dy:int, dx:int):void\n
    SetPosition(y:int, x:int):void\n
    IsMovable():bool\n
    }"]
    
    IMovableRectTarget[label="{
    ＜＜interface＞＞\n
    IMovableRectTarget||
    GetCenterX():int \n
    GetCenterY():int \n
    MoveNext():void\n
    }"]
    
    IRectBounds[label="{
    ＜＜interface＞＞\n
    IRectBounds||
    GetNorthEastX():int\n
    GetNorthEastY():int\n
    GetSouthWestX():int\n
    GetSouthWestY():int\n
    }"]
    
    IShooter[label="{
    ＜＜interface＞＞\n
    IShooter||
    }"]
    
    ITarget[label="{
    ＜＜interface＞＞\n
    ITarget||
    }"]
    
    IUpdatable[label="{
    ＜＜interface＞＞\n
    IUpdatable||
    Update():void
    }"]
    
    PlayerInputManager[label="{
    PlayerInputManager|
    -cWindow:CoreWindow\n
    -shooter:IShooter\n|
    +PlayerInputManager(cWindow:CoreWindow, shooter:IShooter)\n
    +Checkinputs():void\n
    }"]
    
    PlayerShot[label="{
    PlayerShot|
    -shotBrush:Brush\n
    -MAX_X:const float = 10f\n
    -MAX_Y:const float = 10f\n
    -INNER_DIFF:const float = 2f\n
    -isVisible:bool\n|
    +PlayerShot(ctx:DeviceContext)\n
    +Draw():void\n
    +SetPosition(y:int, x:int):void\n
    +GetNorthEastX():int\n
    +GetNorthEastY():int\n
    +GetSouthWestX():int\n
    +GetSouthWestY():int\n
    +IsHitted(c:IRectBounds):bool\n
    +Crash():void\n
    +IsFinished():bool\n
    +IsCrashing():bool\n
    }"]
    
    PlayerShotManager[label="{
    PlayerShotManager|
    - d2dDeviceContext:DeviceContext\n
    - shotList:List＜Shot＞\n
    - drawList:List＜Shot＞\n
    - y:int\n
    - x:int\n
    - SHOT_NUM_MAX:const int = 10\n
    - SHOT_SPEED:const int = -20\n|
    +PlayerShotManager(ctx:DeviceContext)\n
    -Initialize():void\n
    +Fire():void\n
    +Draw():void\n
    +Update():void\n
    +Move(dy:int, dx:int):void\n
    +SetPosition(y:int, x:int):void\n
    +IsMovable():bool\n
    +IsHitted(c:IRectBounds):bool\n
    }"]
    
    RectTargetManager[label="{
    RectTargetManager|
    - context:DeviceContext\n
    - targetList:List＜IMovableRectTarget＞\n
    - playerShotManager:PlayerShotManager\n
    + ENEMY_MAX_NUM:const int = 10\n
    + rng:Random\n|
    +RectTargetManager(ctx:DeviceContext, playerShotManager:PlayerShotManager)
    -Initialize():void\n
    -InitializePosition(e:IMovable):void\n
    +Draw():void\n
    +Update():void\n
    + GetEnemy(index:int):IMovableRectTarget\n
    +GetEnemyCount():int\n
    }"]
    
    ShootingUtils[label="{
    ShootingUtils||
    +IsIntersected(a:IRectBounds, b:IRectBounds):bool
    }"]
    
    Shot[label="{
    Shot|
    +Crash():void \n
    +IsCrashing():bool \n
    +IsFinished():bool \n
    +IsHitted(c:IRectBounds):bool \n
    -d2dDeviceContext:DeviceContext\n
    -centerVector2\n|
    +Shot(ctx:DeviceContext)\n
    +Draw():void\n
    +IsMovable():bool\n
    +Move(dy:int, dx:int):void\n
    +SetPosition(y:int, x:int):void\n
    }"]
    
    SimpleEnemy[label="{
    SimpleEnemy|
    -d2dDeviceContext:DeviceContext \n
    -d2dDevice:Device \n
    -y:int \n
    -x:int \n
    -enemyPath:TransformedGeometry \n
    -enemyBrush:SolidColorBrush \n
    -firstPoint:Vector2 \n
    -secondPoint:Vector2 \n
    -thirdPoint:Vector2 \n
    -isVisible:bool \n
    -MAX_X:const float = 20f \n
    -MAX_Y:const float = 20f \n
    -MOVE_SPEED:const int = 2 \n|
    +SimpleEnemy(ctx:DeviceContext) \n
    -Initialize():void \n
    +Crash():void \n
    +Draw():void \n
    +IsHitted(c:IRectBounds):bool \n
    +IsMovable():bool \n
    +Move(dy:int, dx:int):void \n
    +SetPosition(y:int, x:int):void \n
    +GetNorthEastX():int \n
    +GetNorthEastY():int \n
    +GetSouthWestX():int \n
    +GetSouthWestY():int \n
    +IsFinished():bool \n
    +IsCrashing():bool \n
    +MoveNext():void
    }"]
    
    // クラス継承
	edge [arrowhead = "empty"]
    EnemyShot -> Shot
    IMovableRectTarget -> ITarget, IRectBounds, IMovable
    IShooter -> IMovable, IFirable
    ITarget -> IHittable, ICrashable, IDrawable
    PlayerShot -> Shot
    
    // インターフェース
	edge [arrowhead = "empty" style="dashed"]
    FrameworkViewSource -> IFrameworkViewSource
    FrameworkView -> IFrameworkViewSource
    EnemyShot -> IMovableRectTarget
    EnemyShotManager -> IUpdatable, IHittable, IDrawable
    Fighter -> IShooter, IMovableRectTarget
    PlayerShot -> IRectBounds
    PlayerShotManager -> IDrawable, IMovable, IFirable, IUpdatable, IHittable
    RectTargetManager -> IUpdatable, IDrawable
    Shot -> ITarget, IMovable
    SimpleEnemy -> IMovableRectTarget
    
    // 依存
	edge [arrowhead = "vee" style="dashed"]
    App -> FrameworkViewSource
    FrameworkViewSource -> FrameworkView
    FrameworkView -> PlayerShotManager, Fighter, RectTargetManager, EnemyShotManager,PlayerInputManager
    EnemyShotManager -> EnemyShot, ShootingUtils
    Fighter -> PlayerShotManager, ShootingUtils
    PlayerShot -> ShootingUtils
    PlayerShotManager -> PlayerShot
    RectTargetManager -> SimpleEnemy
    SimpleEnemy -> ShootingUtils
}
``` -->
