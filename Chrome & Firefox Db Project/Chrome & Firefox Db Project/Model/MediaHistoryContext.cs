using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Chrome___Firefox_Db_Project.Model
{
    public partial class MediaHistoryContext : DbContext
    {
        public MediaHistoryContext()
        {
        }

        public MediaHistoryContext(DbContextOptions<MediaHistoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MediaImage> MediaImages { get; set; } = null!;
        public virtual DbSet<Metum> Meta { get; set; } = null!;
        public virtual DbSet<Origin> Origins { get; set; } = null!;
        public virtual DbSet<Playback> Playbacks { get; set; } = null!;
        public virtual DbSet<PlaybackSession> PlaybackSessions { get; set; } = null!;
        public virtual DbSet<SessionImage> SessionImages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=C:\\sqlite\\db\\Media History.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaImage>(entity =>
            {
                entity.ToTable("mediaImage");

                entity.HasIndex(e => e.PlaybackOriginId, "mediaImage_playback_origin_id_index");

                entity.HasIndex(e => new { e.PlaybackOriginId, e.Url }, "mediaImage_playback_origin_id_url_index")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MimeType).HasColumnName("mime_type");

                entity.Property(e => e.PlaybackOriginId).HasColumnName("playback_origin_id");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.PlaybackOrigin)
                    .WithMany(p => p.MediaImages)
                    .HasForeignKey(d => d.PlaybackOriginId);
            });

            modelBuilder.Entity<Metum>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("meta");

                entity.Property(e => e.Key)
                    .HasColumnType("LONGVARCHAR")
                    .HasColumnName("key");

                entity.Property(e => e.Value)
                    .HasColumnType("LONGVARCHAR")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("origin");

                entity.HasIndex(e => e.Origin1, "IX_origin_origin")
                    .IsUnique();

                entity.HasIndex(e => e.AggregateWatchtimeAudioVideoS, "origin_aggregate_watchtime_audio_video_s_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AggregateWatchtimeAudioVideoS)
                    .HasColumnName("aggregate_watchtime_audio_video_s")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HasMediaEngagement).HasColumnName("has_media_engagement");

                entity.Property(e => e.LastUpdatedTimeS).HasColumnName("last_updated_time_s");

                entity.Property(e => e.MediaEngagementHasHighScore).HasColumnName("media_engagement_has_high_score");

                entity.Property(e => e.MediaEngagementLastPlaybackTime).HasColumnName("media_engagement_last_playback_time");

                entity.Property(e => e.MediaEngagementPlaybacks).HasColumnName("media_engagement_playbacks");

                entity.Property(e => e.MediaEngagementVisits).HasColumnName("media_engagement_visits");

                entity.Property(e => e.Origin1).HasColumnName("origin");
            });

            modelBuilder.Entity<Playback>(entity =>
            {
                entity.ToTable("playback");

                entity.HasIndex(e => e.OriginId, "playback_origin_id_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HasAudio).HasColumnName("has_audio");

                entity.Property(e => e.HasVideo).HasColumnName("has_video");

                entity.Property(e => e.LastUpdatedTimeS)
                    .HasColumnType("BIGINT")
                    .HasColumnName("last_updated_time_s");

                entity.Property(e => e.OriginId).HasColumnName("origin_id");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.Property(e => e.WatchTimeS).HasColumnName("watch_time_s");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.Playbacks)
                    .HasForeignKey(d => d.OriginId);
            });

            modelBuilder.Entity<PlaybackSession>(entity =>
            {
                entity.ToTable("playbackSession");

                entity.HasIndex(e => e.Url, "IX_playbackSession_url")
                    .IsUnique();

                entity.HasIndex(e => e.OriginId, "playbackSession_origin_id_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Album).HasColumnName("album");

                entity.Property(e => e.Artist).HasColumnName("artist");

                entity.Property(e => e.DurationMs).HasColumnName("duration_ms");

                entity.Property(e => e.LastUpdatedTimeS)
                    .HasColumnType("BIGINT")
                    .HasColumnName("last_updated_time_s");

                entity.Property(e => e.OriginId).HasColumnName("origin_id");

                entity.Property(e => e.PositionMs).HasColumnName("position_ms");

                entity.Property(e => e.SourceTitle).HasColumnName("source_title");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.PlaybackSessions)
                    .HasForeignKey(d => d.OriginId);
            });

            modelBuilder.Entity<SessionImage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sessionImage");

                entity.HasIndex(e => e.ImageId, "sessionImage_image_id_index");

                entity.HasIndex(e => e.SessionId, "sessionImage_session_id_index");

                entity.HasIndex(e => new { e.SessionId, e.ImageId, e.Width, e.Height }, "sessionImage_session_image_index")
                    .IsUnique();

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.Image)
                    .WithMany()
                    .HasForeignKey(d => d.ImageId);

                entity.HasOne(d => d.Session)
                    .WithMany()
                    .HasForeignKey(d => d.SessionId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
