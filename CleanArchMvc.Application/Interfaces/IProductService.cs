﻿using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int? id);

        Task<ProductDTO> GetProductCategory(int? id);
        Task Add(ProductDTO productDto);
        Task Update(ProductDTO productDto);
        Task Remove(int? id);
    }
}
