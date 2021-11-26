using EHS.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHS.DbContexts
{
    public partial class EHSContext : DbContext
    {

        public EHSContext()
        {
        }

        public EHSContext(DbContextOptions<EHSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EhsCourse> EhsCourses { get; set; }
        public virtual DbSet<EhsCoursefolder> EhsCoursefolders { get; set; }
        public virtual DbSet<EhsCoursefoldercourseware> EhsCoursefoldercoursewares { get; set; }
        public virtual DbSet<EhsCoursearrange> EhsCoursearranges { get; set; }
        public virtual DbSet<EhsCourseware> EhsCoursewares { get; set; }
        public virtual DbSet<EhsExam> EhsExams { get; set; }
        public virtual DbSet<EhsExamarrange> EhsExamarranges { get; set; }
        public virtual DbSet<EhsExamquestionscore> EhsExamquestionscores { get; set; }
        public virtual DbSet<EhsExamrecord> EhsExamrecords { get; set; }
        public virtual DbSet<EhsLib> EhsLibs { get; set; }
        public virtual DbSet<EhsOccupationalhazard> EhsOccupationalhazards { get; set; }
        public virtual DbSet<EhsQuestion> EhsQuestions { get; set; }
        public virtual DbSet<EhsStudyrecord> EhsStudyrecords { get; set; }
        public virtual DbSet<EhsStudiedcourseware> EhsStudiedcoursewares {  get; set; } 
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        string a = "USER ID=SCOTT;Password=123456; DATA SOURCE=127.0.0.1:1521/ORCL;PERSIST SECURITY INFO=True";
        //        string s = @"TNS_ADMIN=C:\Users\qjun\Oracle\network\admin;USER ID=SCOTT;Password=123456;DATA SOURCE=localhost:1521/orcl.shenmapower.com;PERSIST SECURITY INFO=True";
        //        string d = "User ID=scott;Password=chxlQqxMbdwWlc;DATA SOURCE=192.168.4.175:1521/orcl.168.4.175;Persist Security Info=True;";
        //        string j = "USER ID=SCOTT;Password=123456; DATA SOURCE=127.0.0.1:1521/ORCL;PERSIST SECURITY INFO=True";
        //        // optionsBuilder.UseOracle("USER ID=EHS;Password=EHS4ehs3; DATA SOURCE=127.0.0.1:1521/ORCL;PERSIST SECURITY INFO=True", b => b.UseOracleSQLCompatibility("11"));
        //        optionsBuilder.UseOracle(d, b => b.UseOracleSQLCompatibility("11"));

        //    }
        //}

        /// <summary>
        /// 进一步配置注册映射模型
        /// </summary>
        /// <param name="modelBuilder">用于为该上下文构造模型的构造器</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}