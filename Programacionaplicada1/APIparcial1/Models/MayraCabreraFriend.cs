using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIparcial.Models
{
    public enum FriendType
    {
        Conocido,
        CompañeroEstudio,
        ColegaTrbajo,
        Amigo,
        AmigoInfancia,
        Pariente

    }



    public class MayraCabreraFriend
    {


        [Key]
        public int FriendId { get; set; }
        [Required]
        public string Name { get; set; }
        public string DateType { get; set; }
        public string Apodo { get; set; }
      public FriendType TipoAmigo { get; set; }
       
        
    }
}