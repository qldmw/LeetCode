using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructure
{
    class List
    {
        ///Unsolved Question:
        ///1.List是连续的内存空间，删除中间的元素之后应该会发生内存移动才对，但是显然不可能这么做，因为性能消耗太大，不值得，好奇List是通过什么方法完成的。
        ///2.看源码的时候看到一个 _version，估计是一个什么更新版本之类的东西，之后仔细研究下是什么用。

        ///源码地址：https://source.dot.net/#System.Private.CoreLib/List.cs
        ///1.看了源码中的 Remove 方法，然而并没有什么黑科技，即使简单调用了 Array.CoreCLR.cs 中的 Copy 方法，这个方法的 unsafe 的，
        ///在操作内存，具体的代码涉及了很多底层的东西，只看了个大概懂，总之就是调用了 BulkMoveWithWriteBarrier 方法，移动了内存，也就
        ///是说还是移动的内存。嗯，但是为什么感觉 Remove 也不慢呢。。（又去找了下标访问的实现，发现的确就是简单的访问，如果有黑科技的话，
        ///下标访问应该也是要做对应的处理才对。）
    }

    class HashSet
    {
        ///Unsolved Question
        ///1.HashSet的Add是如果动态扩容的，标准hash因为是对一个固定值取模才对啊，如果扩容了要所有重算hash才对。不过我觉得应该不会重算吧，太影响了，好奇怎么实现的。
        
        ///源码地址：https://source.dot.net/#System.Private.CoreLib/HashSet.cs
        ///本来想把源码贴过来调试的，但是发现不方便，还是直接写学习源码后获得的知识吧。
        ///
        ///1.
    }
}