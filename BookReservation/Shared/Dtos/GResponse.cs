using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookReservation.Shared.Dtos
{
    public class GResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSucces { get; set; }

        public GResponse()
        {

        }
        
        public GResponse(string errorMessage)
        {
            IsSucces = false;
            Message = errorMessage;
        }

        public GResponse(string successMessage, T data)
        {
            IsSucces = true;
            Data = data;
            Message = successMessage;
        }
    }
}
