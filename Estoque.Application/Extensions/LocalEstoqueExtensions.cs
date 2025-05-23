﻿using Estoque.Domain.Modelos;
using Estoque.Application.DTO;

namespace Estoque.Application.Extensions
{
    public static class LocalEstoqueExtensions
    {
        public static LocalEstoqueDTO toLocalEstoqueDTO(this LocalEstoque localEstoque)
        {
            return new LocalEstoqueDTO
            {
                id = localEstoque.id,
                nome = localEstoque.nome,
                usuario = localEstoque.usuario.email,
            };
        }
        public static IEnumerable<LocalEstoqueDTO> toLocaisEstoqueDTO(this IEnumerable<LocalEstoque> locaisEstoque)
        {
            return locaisEstoque.Select(x => x.toLocalEstoqueDTO());
        }
    }
}
