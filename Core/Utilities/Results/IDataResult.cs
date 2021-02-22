using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
  public  interface IDataResult<T>:IResult
    {
        // Message ve success zaten IResult dan gelicek biz burada sadec T tipinde Data
        T Data { get; }

    }
}
