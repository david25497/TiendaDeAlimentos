using System.Collections.Generic;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.ApiResult;

namespace TiendaDeAlimentos.Core.Application.Services.SystemConfig.ApiResult
{
    /// <summary>
    /// El siguiente modelo de datos se utiliza para retornar el resultado de forma generica.
    /// </summary>
    public class Result : IResult
    {
        public bool Successed { get; set; }

        public bool Failed => !Successed;

        public List<string> Messages { get; set; } = new List<string>();

        public static IResult Fail()
        {
            return new Result { Successed = false };
        }

        public static IResult Fail(string Message)
        {
            return new Result { Successed = false, Messages = new List<string> { Message } };
        }

        public static IResult Fail(List<string> Messages)
        {
            return new Result { Successed = false, Messages = Messages };
        }

        public static IResult Success()
        {
            return new Result { Successed = true };
        }

        public static IResult Success(string Message)
        {
            return new Result { Successed = true, Messages = new List<string> { Message } };
        }

        public static IResult Success(List<string> Messages)
        {
            return new Result { Successed = true, Messages = Messages };
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public T Data { get; set; }

        #region SIN DATA
        public static new Result<T> Fail()
        {
            return new Result<T> { Successed = false };
        }

        public static new Result<T> Fail(string Message)
        {
            return new Result<T> { Successed = false, Messages = new List<string> { Message } };
        }

        public static new Result<T> Fail(List<string> Messages)
        {
            return new Result<T> { Successed = false, Messages = Messages };
        }

        public static new Result<T> Success()
        {
            return new Result<T> { Successed = true };
        }

        public static new Result<T> Success(string Message)
        {
            return new Result<T> { Successed = true, Messages = new List<string> { Message } };
        }

        public static new Result<T> Success(List<string> Messages)
        {
            return new Result<T> { Successed = true, Messages = Messages };
        }
        #endregion

        #region CON DATA
        public static Result<T> Fail(T Data)
        {
            return new Result<T> { Successed = false, Data = Data };
        }

        public static Result<T> Fail(string Message, T Data)
        {
            return new Result<T> { Successed = false, Messages = new List<string> { Message }, Data = Data };
        }

        public static Result<T> Fail(List<string> Messages, T Data)
        {
            return new Result<T> { Successed = false, Messages = Messages, Data = Data };
        }

        public static Result<T> Success(T Data)
        {
            return new Result<T> { Successed = true, Data = Data };
        }

        public static Result<T> Success(string Message, T Data)
        {
            return new Result<T> { Successed = true, Messages = new List<string> { Message }, Data = Data };
        }

        public static Result<T> Success(List<string> Messages, T Data)
        {
            return new Result<T> { Successed = true, Messages = Messages, Data = Data };
        }
        #endregion
    }

}
