using System;
using System.Text;

    /// <summary>
    /// ログ出力
    /// </summary>
    public sealed class Logger
    {
        /// <summary>
        /// ログ出力先
        /// </summary>
        public static string LogDirectory;

        /// <summary>
        /// ログファイル名
        /// </summary>
        const string LogFileName = "Log.txt";

        /// <summary>
        /// ログ処理 インスタンス
        /// </summary>
        private static readonly Logger _Logger = new Logger();
        /// <summary>
        /// インスタンス取得
        /// </summary>
        /// <returns></returns>
        public static Logger GetInstance()
        {
            return _Logger;
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="message">出力メッセージ</param>
        /// <param name="throwError">false：エラー無視 true：エラーをthrowする</param>
        public static void Log(string message, bool throwError = false)
        {
            System.IO.StreamWriter sr = null;
            Encoding enc = null;
            try
            {
                enc = Encoding.GetEncoding("Shift_JIS");
                // 日付（yyyyddmm）+ Log.txtを取得する
                sr = new System.IO.StreamWriter(LogDirectory + DateTime.Now.ToString("yyyyMMdd") + LogFileName, true, enc);
                // メッセージ書き込む
                sr.WriteLine(message);
            }
            catch
            {
                if (throwError) throw;
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }

        /// <summary>
        /// エラー出力
        /// </summary>
        /// <param name="message">出力メッセージ</param>
        /// <param name="e">エラー詳細(Exception)</param>
        /// <param name="throwError">false：エラー無視 true：エラーをthrowする</param>
        public static void ErrLog(string message, Exception e = null, bool throwError = false)
        {
            System.IO.StreamWriter sr = null;
            Encoding enc = null;
            try
            {
                enc = Encoding.GetEncoding("Shift_JIS");
                // 日付（yyyyddmm）+ Log.txtを取得する
                sr = new System.IO.StreamWriter(LogDirectory + DateTime.Now.ToString("yyyyMMdd") + LogFileName, true, enc);
                // メッセージ書き込む
                sr.WriteLine("Error Log >>" + message + " 詳細：" + (e != null ? e.ToString() : "----"));
            }
            catch
            {
                if (throwError) throw;
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }

        /// <summary>
        /// ワーニング出力
        /// </summary>
        /// <param name="message">出力メッセージ</param>
        /// <param name="e">エラー詳細(Exception)</param>
        /// <param name="throwError">false：エラー無視 true：エラーをthrowする</param>
        public static void WarningLog(string message, Exception e = null, bool throwError = false)
        {
            System.IO.StreamWriter sr = null;
            Encoding enc = null;
            try
            {
                enc = Encoding.GetEncoding("Shift_JIS");
                // 日付（yyyyddmm）+ Log.txtを取得する
                sr = new System.IO.StreamWriter(LogDirectory + DateTime.Now.ToString("yyyyMMdd") + LogFileName, true, enc);
                // メッセージ書き込む
                sr.WriteLine("Warning Log >>" + message + " 詳細：" + (e != null ? e.ToString() : "----"));
            }
            catch
            {
                if (throwError) throw;
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }
    }
