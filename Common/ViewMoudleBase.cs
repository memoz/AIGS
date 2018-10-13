﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AIGS.Common
{
    public class ViewMoudleBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #region 数据校验
        /// <summary>
        /// 数据校验的回调接口
        /// </summary>
        /// <param name="sPropertyName"></param>
        /// <sample>
        /// string CallBackDataCheck(string sName)
        /// {
        ///     if(sName == "m_Count")
        ///     {
        ///         if(m_Count < 0)
        ///             return "Count need bigger than 0";
        ///     }
        ///     return string.Empty;
        /// }
        /// </sample>
        /// <returns></returns>
        public delegate string DataCheckFunc(string sPropertyName);
        public DataCheckFunc CallBackDataCheck;

        /// <summary>
        /// 数据校验实现
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                if (CallBackDataCheck != null)
                {
                    string result = CallBackDataCheck(columnName);
                    return result;
                }

                return string.Empty;
            }
        }
        #endregion
    }
}