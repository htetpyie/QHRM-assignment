using ProductMS.Shared.Enums;

namespace ProductMS.Features;

public class Result<T>
{
	public bool IsSuccess { get; set; }
	public bool IsError => !IsSuccess;
	public EnumErrorType? ErrorType { get; set; }
	public string? Message { get; set; }
	public List<string> MessageList { get; set; } = [];
	public T? Data { get; set; }
	public string? Code { get; set; }

	public static Result<T> Success(string? message, T? data = default, string code = null)
	{
		return new Result<T> { IsSuccess = true, Message = message, Data = data, Code = code };
	}

	public static Result<T> Fail(
		string? message, EnumErrorType errorType = EnumErrorType.Error, string code = null)
	{
		return new Result<T> { IsSuccess = false, Message = message, ErrorType = errorType, Code = code };
	}

	public static Result<T> FailValidation(List<string>? messageList)
	{
		return new Result<T> { IsSuccess = false, MessageList = messageList, ErrorType = EnumErrorType.Warning };
	}
}

public class Result
{
	public static Result<T> Success<T>(int statusCode, string message, T data)
	{
		return new Result<T> { IsSuccess = true, Message = message, Data = data };
	}

	public static Result<T> Fail<T>(int statusCode, string message)
	{
		return new Result<T>
		{
			IsSuccess = false,
			Message = message,
			Data = default
		};
	}
}