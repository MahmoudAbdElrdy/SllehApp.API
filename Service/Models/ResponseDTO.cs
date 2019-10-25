using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.Models
{
    public interface IResponseDTO
    {
        #region Public Properties
        bool IsPassed { get; set; }

        string Message { get; set; }

        dynamic Data { get; set; }
        #endregion
    }
    public class ResponseDTO : IResponseDTO
    {
        public ResponseDTO()
        {
            IsPassed = false;
            Message = "";
        }
        public bool IsPassed { get; set; }

        public string Message { get; set; }

        public dynamic Data { get; set; }

        public void Copy(ResponseDTO x)
        {
            IsPassed = x.IsPassed;
            Message = x.Message;
            Data = x.Data;
        }
    }
}
