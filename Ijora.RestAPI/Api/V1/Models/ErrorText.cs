namespace Ijora.RestAPI.Api.V1.Models
{
    public struct ErrorText
    {
        public static ErrorText UNAUTHORIZED
            = new ErrorText("Не авторизован");

        public static ErrorText EMPTY_AUTH_CODE
            = new ErrorText("Пустой код авторизации");

        public static ErrorText NO_PERMISSION
            = new ErrorText("Недостаточно прав для выполнения операции");

        public string Text { get; }

        private ErrorText(string text)
        {
            Text = text;
        }

        public override string ToString() => Text;

        public ErrorResponseModel AsResponseModel() => new ErrorResponseModel(Text);
        public ErrorResponseModel AsResponseModel(params object[] args) => new ErrorResponseModel(string.Format(Text, args));
    }
}
