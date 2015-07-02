﻿using System;
using ImageQuery.Environment;
using ImageQuery.Query.Value;

namespace ImageQuery.Query.Operators
{
    public class AndExpression : AbstractOperatorExpression
    {
        public override IQueryValue EvaluateOperator(IEnvironment env, IQueryValue left, IQueryValue right)
        {
            switch (left.GetIQLType())
            {
                default:
                    throw new ArgumentException(string.Format("Arguments to AND cannot be of type {0}", left.GetIQLType()));

                case IQLType.Boolean:
                    return new BooleanValue() { Boolean = left.Boolean && right.Boolean };
            }
        }
    }
}