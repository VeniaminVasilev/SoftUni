﻿namespace Logger.Interfaces
{
    public interface ILayout
    {
        string Format(string dateTime, string reportLevel, string message);
    }
}