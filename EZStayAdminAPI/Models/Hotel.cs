using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZStayAdminAPI.Model
{
    [Table("Hotels")]
    public class HotelInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Name of Hotel cannot be empty")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Rating of Hotel cannot be empty")]
        
        public int Rating { get; set; }

        [Required(ErrorMessage = "Address of Hotel cannot be empty")]
        [Column(TypeName = "varchar(50)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City of Hotel cannot be empty")]
        [Column(TypeName = "varchar(20)")]
        public string City { get; set; }


        [Required(ErrorMessage = "Phone of Hotel cannot be empty")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        [DataType(DataType.Url)]
        [Required(ErrorMessage = "Hotel Image url cannot be empty")]
        [Display(Name = " Hotel Photo URL")]
        public string HotelPhotoUrl { get; set; }

       public List<RoomInfo> Rooms { get; set; }

    }

    [Table("Rooms")]
    public class RoomInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        public int HotelId { get; set; }

        [Required(ErrorMessage = "Name of Room cannot be empty")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Occupancy cannot be empty")]
        public int Occupancy { get; set; }

        [Required(ErrorMessage = "Room type cannot be empty")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }

       public List<AmenitiesInfo> Amenities { get; set; }

    }

    [Table("Amenities")]
    public class AmenitiesInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RoomId { get; set; }
        [Display(Name = "Is Wifi Available")]
        public Boolean IsWIFI { get; set; }
        [Display(Name = "Is AC Available")]
        public Boolean IsAC { get; set; }
        [Display(Name = "Is Swiming Pool Available")]
        public Boolean IsSwimingPool { get; set; }

    }


}
