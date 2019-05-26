﻿using Natasha.Engine.Builder;
using System;
using System.Reflection;

namespace Natasha
{
    public class ClassBuilder:ClassContentTemplate<ClassBuilder>
    {
        public CtorTemplate CtorBuilder;
        public ClassBuilder()
        {
            CtorBuilder = new CtorTemplate();
            Link = this;
        }
        static ClassBuilder()
        {

        }
        public override string Builder()
        {
            Script.Append(CtorBuilder.Builder());
            return base.Builder();
        }
        public Type GetType(int classIndex = 1, int namespaceIndex = 1)
        {
            return GetType(Builder(), classIndex, namespaceIndex);
        }
        /// <summary>
        /// 根据命名空间和类的位置获取类型
        /// </summary>
        /// <param name="content">脚本内容</param>
        /// <param name="classIndex">命名空间里的第index个类</param>
        /// <param name="namespaceIndex">第x个命名空间</param>
        /// <returns></returns>
        public static Type GetType(string content, int classIndex = 1, int namespaceIndex = 1)
        {
            classIndex -= 1;
            namespaceIndex -= 1;
            Assembly assembly = null;
            string className = ScriptComplier.GetClassName(content, classIndex, namespaceIndex);
            assembly = ScriptComplier.FileComplier(content, className);
            return AssemblyOperator.Loader(assembly)[className];
        }
    }
}
