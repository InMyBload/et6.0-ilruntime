[ET论坛](https://et-framework.cn)  
[ET框架](https://github.com/egametang/ET)  6.0版本Matser  接入了Ilruntime 1.6.7

基本保留了原本6.0的文件结构

待完成
   EventSystem ILRuntime中只能使用 GetCustomAttributes( typeof(当前类的Att),false) 不可以通过继承链查询att    需要增加判断父类中是否包含自己所需要的Attribute 这样很多地方不需要重新打Attribute 只需要父类中一个 Attribute就足够
   很多地方的代码为了省事  看起来很丑
   生成proto 需要修改  ResponseTypeAttribute 需要修改参数为string (偷懒了 没测试 不修改的情况下会不会有问题  看烟雨的修改了 所以 为了省事也修改一下)
   生成配置  需要修改  需要去掉 ProtoAfterDeserialization 特性


参考 [et-6-with-ilruntime](https://www.lfzxb.top/et-6-with-ilruntime/) 烟雨接入的ILruntime