﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Koton.Shared.Response
{
    public class Response<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccesful { get; set; }
        public List<string> Errors { get; set; }

        public static Response<T> Succes(T data, int statusCode) => new Response<T> { Data = data, StatusCode = statusCode, IsSuccesful = true };
        public static Response<T> Succes(int statusCode) => new Response<T> { StatusCode = statusCode, IsSuccesful = true };

        public static Response<T> Fail(List<string> errors, int statusCode) => new Response<T>
            { Errors = errors, StatusCode = statusCode, IsSuccesful = false };

        public static Response<T> Fail(string error, int statusCode) => new Response<T>
            { Errors = [error], StatusCode = statusCode, IsSuccesful = false };
    }
}
