using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolManagement
{
    // Giao diện IDbCommandInterceptor chứa các phương thức chặn một đối tượng của DbContext
    // và cho phép bạn thực thi logic tùy chỉnh của mình trước hoặc sau khi ngữ cảnh thực hiện các lệnh hoặc truy vấn
    // cần phải định cấu hình bộ chặn bằng cách sử dụng tệp cấu hình (app.config) hoặc cấu hình dựa trên mã nguồn
    class EFCommandInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo("NonQueryExecuted", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo("NonQueryExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogInfo("ReaderExecuted", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogInfo("ReaderExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo("ScalarExecuted", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo("ScalarExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        private void LogInfo(string command, string commandText)
        {
            Console.WriteLine("Intercepted on: {0} :- {1} ", command, commandText);
        }
    }
}
