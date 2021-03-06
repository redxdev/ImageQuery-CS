﻿using ImageQuery.Canvas;
using ImageQuery.Query.Value;

namespace ImageQuery.Environment
{
    public delegate IQueryValue QueryFunction(IEnvironment env, IQueryValue[] arguments);

    public interface IEnvironment
    {
        IQLSettings Settings { get; }

        ICanvas CreateInput(string name);

        ICanvas CreateOutput(string name, int w, int h);

        ICanvas CreateIntermediate(string name, int w, int h);

        void CreateVariable(string name, IQueryValue value);

        void SetVariable(string name, IQueryValue value);

        IQueryValue GetVariable(string name);

        void CreateParameter(string name, IQueryValue value);

        IQueryValue GetParameter(string name);

        bool HasParameter(string name);

        void RegisterFunction(string name, QueryFunction func);

        QueryFunction GetFunction(string name);
    }
}
