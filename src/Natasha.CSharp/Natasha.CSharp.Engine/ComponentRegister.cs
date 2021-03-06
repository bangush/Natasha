﻿using Microsoft.CodeAnalysis.CSharp;
using Natasha.CSharpEngine;
using Natasha.Framework;



public static class NatashaComponentRegister
{

    public static void RegistCompiler<TCompiler>() where TCompiler : CompilerBase<CSharpCompilation, CSharpCompilationOptions>, new()
    {
        CompilerManagement.RegisterDefault<TCompiler>();
    }

    public static void RegistDomain<TDomain>(bool initializeReference = true) where TDomain : DomainBase
    { 
        DomainManagement.RegisterDefault<TDomain>(initializeReference);
    }

    public static void RegistSyntax<TSyntax>() where TSyntax : SyntaxBase, new()
    {
        SyntaxManagement.RegisterDefault<TSyntax>();
    }

}

