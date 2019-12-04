using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Soulstice.DATA.EF
{
    #region Gym Member Metadata

    public class GymMemberMetadata
    {
        public string GymID { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Goal")]
        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string GoalDescription { get; set; }

        [Display(Name = "Profile Picture")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string ProfilePic { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "* The value must be 13 characters or less.")]
        public string Phone { get; set; }

    }

    [MetadataType(typeof(GymMemberMetadata))]
    public partial class GymMember
    {
        [Display(Name = "Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string FormattedPhone
        {
            get { return PhoneNumber.Format(Phone);  }
        }
    }
    #endregion

    #region Class Metadata

    public class ClassMetadata
    {
        //public int ClassID { get; set; }

        [Display(Name = "Class")]
        [Required]
        [StringLength(50, ErrorMessage = "* The value requires 50 characters or less.")]
        public string ClassName { get; set; }

        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Description { get; set; }

        public int InstructorID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Reservation Limit")]
        [Range(1, double.MaxValue, ErrorMessage = "* Value must be a valid number, 1 or larger.")]
        public int ReservationLimit { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "* Value must be a valid number, 0 or larger.")]
        public decimal Fee { get; set; }

        
        public int WeekDayID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This value requires 50 characters or less")]
        public string Time { get; set; }
    }

    [MetadataType(typeof(ClassMetadata))]
    public partial class Class
    {

    }

    #endregion

    #region Instructor Metadata

    public class InstructorMetadata
    {
        //public int InstructorID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This value requires 50 characters or less")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This value requires 50 characters or less")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This value requires 50 characters or less")]
        public string Specialty { get; set; }
    }

    [MetadataType(typeof(InstructorMetadata))]
    public partial class Instructor
    {
        [Display(Name = "Instructor")]
        public string InstructorName
        {
            get { return FirstName + " " + LastName;  }
        }
    }
    #endregion

    #region Reservation Metadata

    public class ReservationMetadata
    {

    }

    public partial class Reservation
    {

    }
    #endregion

    #region WeekDay metadata

    public class WeekDayMetadata
    {

        [Display(Name = "Day of Week")]
        public string DayOfWeek { get; set; }
    }

    [MetadataType(typeof(WeekDayMetadata))]
    public partial class WeekDay
    {

    }
    #endregion

    #region Format Phone Number
    public static class PhoneNumber
    {
        public static string Format(this string s)
        {
            int count = s.Length;
            string formattedPhone = "";

            string npa = string.Format("({0}) ", s.Substring(0, 3));
            string nxx = string.Format("{0} - ", s.Substring(2, 3));
            string line = string.Format("{0}", s.Substring(5, 4));
            //string ext = count > 9 ? " Ext: " + s.Substring(9) : "";

            formattedPhone = npa + nxx + line;

            return formattedPhone;
        }
    }


    #endregion
}
