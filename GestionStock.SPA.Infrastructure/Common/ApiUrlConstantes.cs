using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.SPA.Infrastructure.Common
{
    public static class ApiUrlConstantes
    {
        #region Product
        public const string  GetAllProductApiUrl = "/api/Product/get-all-products";
        public const string CreateProductApiUrl = "/api/Product/create-product";
        public const string GetByIdProductApiUrl = "/api/Product/get-product-id";
        public const string UpdateProductApiUrl = "/api/Product/update-product";
        public const string DeleteProductApiUrl = "/api/Product/delete-product";
        #endregion

        #region ChatGPT
        public const string ChatGPTPromptApiUrl = "/api/ChatGPT/prompt";
        #endregion
    }
}
