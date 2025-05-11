using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    //TODO: record yapısı, C# 9.0 ile gelen bir referans tipi (class gibi) ama immutable yani değiştirilemez veri yapısıdır.
    //TODO: 1-Veri taşıma amacıyla (DTO – Data Transfer Object) 2-eğer (value-based) karşılaştırmalar için 3-Okunabilirliği yüksek, sade yapılar için
    //TODO: DTO lar readonly olarak tanımlanması lazım bunun için  { get; init; } şeklinde tanımlanabilir.
    public record BookDtoUpdate : BookDtoForManipulaton //TODO: Artık Validaiton için yazdığımız BookDtoForManipulatonclasından kalıtım alacak
    {
        [Required]
        public int Id { get; init; }
        
    }
}
