﻿namespace Aisino.Fwkp.Fpzpz.Entry
{
    using Aisino.Framework.Plugin.Core;
    using Aisino.Framework.Plugin.Core.Command;
    using Aisino.Framework.Plugin.Core.Util;
    using Aisino.Fwkp.Fpzpz.Common;
    using System;

    public sealed class PzMsgSetEntry : AbstractCommand
    {
        protected override bool SetValid()
        {
            try
            {
                string str = PropertyUtil.GetValue(DingYiZhiFuChuan.StartStopPfzpzJieKou);
                if (string.IsNullOrEmpty(str))
                {
                    str = "0";
                    PropertyUtil.SetValue(DingYiZhiFuChuan.StartStopPfzpzJieKou, "0");
                }
                return !str.Trim().Equals("0");
            }
            catch (BaseException exception)
            {
                ExceptionHandler.HandleError(exception);
            }
            catch (Exception exception2)
            {
                ExceptionHandler.HandleError(exception2);
            }
            return true;
        }
    }
}

