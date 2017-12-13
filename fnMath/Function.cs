// --------------------------------------------------
// Created by Steven Novak 
// 
// 11 / 21 / 2017
// --------------------------------------------------
//
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fnMath
{
    public interface Function
    {
        double Evaluate(double x);

        double Evaluate(Vector<double> X);
    }
}
