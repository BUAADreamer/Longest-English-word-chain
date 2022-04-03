using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Library;
using Core;
namespace Cmd 
{
    class Program
    {
        static void Main(string[] args)
        {
            //CoreType:0 使用我们的Core
            //CoreType:1 使用交换的Core
            int CoreType = 0;
            if (CoreType == 0)
            {
                CmdTestInterface.Solve(args, "");
            }
            else
            {

            }
        }
        
    }
}


