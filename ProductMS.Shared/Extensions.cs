﻿using ProductMS.Shared.Models;

namespace ProductMS.Shared
{
	public static class Extensions
	{
		public static DatatableResponseModel<T> ChangeDatatableResponse<T>(
			this DatatableRequestModel request, List<T> data, int totalRecord)
		{
			var response = new DatatableResponseModel<T>();
			response.Draw = request.Draw;
			response.Data = data;
			response.RecordsTotal = totalRecord;
			response.RecordsFiltered = totalRecord;
			return response;
		}

		public static string Format(this string str, params object[] args)
		{
			return String.Format(str, args);
		}

	}
}
