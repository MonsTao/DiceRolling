此包是一个随机数生成器，用于产生与掷骰子分布一致的随机正整数。其含有以下公有方法：


OneDiceRolling：传入正整数n，返回一个n面骰的掷骰结果，若传入两个整数，则第二个为修正值

MultiDicesRolling：传入两个整数，依次为骰子数量n和骰子面数m，返回nDm的结果，若传入三个整数，则第三个为修正值

Check：传入两个整数，依次为补正值与难度值，骰D20检定。检定成功返回true，失败false。

VaryDiceRolling：传入任意个整数，每个整数n对应骰一次n面骰，返回所有点数总和

PairdVaryDiceRolling：传入偶数个正整数，每次取两个数n和m，骰nDm，返回总和。