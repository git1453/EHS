using EHS.DbContexts.EntityTypeConfiguration;
using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EHS.DbContexts
{
    public partial class EHSContext : DbContext
    {


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
        [Obsolete]
        public virtual DbSet<EhsOccupationalhazard> EhsOccupationalhazards { get; set; }
        [Obsolete]
        public virtual DbSet<EhsQuestion> EhsQuestions { get; set; }
        public virtual DbSet<EhsStudyrecord> EhsStudyrecords { get; set; }
        public virtual DbSet<EhsStudiedcourseware> EhsStudiedcoursewares {  get; set; }

        /// <summary>
        /// 进一步配置注册映射模型
        /// </summary>
        /// <param name="modelBuilder">用于为该上下文构造模型的构造器</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.HasDefaultSchema("SCOTT");

            modelBuilder.ApplyConfiguration(new EhsExamConfiguration());
            modelBuilder.ApplyConfiguration(new EhsExamquestionscoreConfiguration());
            modelBuilder.ApplyConfiguration(new EhsExamrecordConfiguration());
            modelBuilder.ApplyConfiguration(new EhsExamarrangeConfiguration());

            modelBuilder.ApplyConfiguration(new EhsLibConfiguration());

            modelBuilder.ApplyConfiguration(new EhsCourseConfiguration());
            modelBuilder.ApplyConfiguration(new EhsCoursearrangeConfiguration());
            modelBuilder.ApplyConfiguration(new EhsCoursefolderConfiguration());
            modelBuilder.ApplyConfiguration(new EhsCoursefoldercoursewareConfiguration());

            modelBuilder.ApplyConfiguration(new EhsCoursewareConfiguration());
            modelBuilder.ApplyConfiguration(new EhsStudiedcoursewareConfiguration());
            modelBuilder.ApplyConfiguration(new EhsStudyrecordConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        [Obsolete]
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EhsQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new EhsOccupationalhazardConfiguration());
        }
    }
}