﻿using System;

namespace app_for_xml.infrastructure.@interface.services {
    public interface ILogger {
        void Info(string message);
        void Error(string message, Exception e);
        void Error(string message);
        void Error(Exception e);
        void Fatal(string message, Exception e);
        void Fatal(string message);
        void Debug(string message);
        void Warn(string message);
    }
}
