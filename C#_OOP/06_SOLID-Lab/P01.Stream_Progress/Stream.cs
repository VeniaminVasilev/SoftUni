﻿namespace P01.Stream_Progress
{
    public interface IStream
    {
        int Length { get; }

        int BytesSent { get; }
    }
}