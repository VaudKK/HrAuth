using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HrAuth.Dto{

    public class ResponseDto{

        public bool success { get; set; }
        public string token { get; set; }
        public IEnumerable<string> errors { get; set; }

    }

}