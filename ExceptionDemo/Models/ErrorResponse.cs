﻿namespace ExceptionDemo.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
    }
}