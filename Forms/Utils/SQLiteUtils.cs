using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Sqlite;
using QZhihuFind.Models.SQLiteModels;

namespace QZhihuFind.Utils
{
	public class SQLiteUtils
	{
		private static SQLiteUtils instance;
		public static SQLiteUtils Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new SQLiteUtils();
				}
				return instance;
			}
		}

		public Database DataBase { get; set; }
		public string DataBaseName { get; set; } = "QZhihuFind.db";

		public SQLiteUtils()
		{
			DataBase = new Database(DataBaseName);
			CreateTable();
		}

		private void CreateTable()
		{
			DataBase.CreateTable<DailysImagesModel>();
			DataBase.CreateTable<DailyExtraModel>();
			DataBase.CreateTable<DailysModel>();
			DataBase.CreateTable<TopDailysModel>();
			DataBase.CreateTable<DailyModel>();
			DataBase.CreateTable<DailyJsModel>();
			DataBase.CreateTable<DailyCssModel>();
			DataBase.CreateTable<ArticleModel>();
			DataBase.CreateTable<AuthorModel>();
			DataBase.CreateTable<AvatarModel>();

			DataBase.CreateTable<CollectionModel>();

		}

		public List<Models.JsonModels.DailysModel> QueryAllDailys()
		{
			var vDailys = new List<Models.JsonModels.DailysModel>();

			var dailys = DataBase.Table<DailysModel>().ToList();
			foreach (var item in dailys)
			{
				var extras = DataBase.Table<DailyExtraModel>().Where(d => d.Id == item.Id).FirstOrDefault();
				var images = DataBase.Table<DailysImagesModel>().Where(d => d.DailyId == item.Id).ToList();
				var vImages = new List<string>();
				foreach (var i in images)
				{
					vImages.Add(i.Images);
				}
				var daily = new Models.JsonModels.DailysModel()
				{
					Id = item.Id,
					Date = item.Date,
					Ga_prefix = item.Ga_prefix,
					Title = item.Title,
					Images = vImages
				};
				if (extras != null)
				{
					daily.extra = new Models.JsonModels.DailyExtraModel()
					{
						comments = extras.comments,
						long_comments = extras.long_comments,
						popularity = extras.popularity,
						short_comments = extras.short_comments
					};
				}
				else
				{
					daily.extra = new Models.JsonModels.DailyExtraModel();
				}
				vDailys.Add(daily);
			}
			return vDailys;
		}
		public void DeleteAllDailys()
		{
			DataBase.DeleteAll<DailysImagesModel>();
			DataBase.DeleteAll<DailysModel>();
		}
		public void UpdateAllDailys(List<Models.JsonModels.DailysModel> lists)
		{
			foreach (var item in lists)
			{
				DataBase.DeleteItem<DailysImagesModel>(item.Id);

				foreach (var img in item.Images)
				{
					DataBase.InsertItem(new DailysImagesModel
					{
						DailyId = item.Id,
						Images = img
					});
				}
				if (item.extra != null)
				{
					item.extra.id = item.Id;
					UpdateDailyExtra(item.extra);
				}
				DataBase.DeleteItem<DailysModel>(item.Id);
				DataBase.InsertItem(new DailysModel
				{
					Id = item.Id,
					Date = item.Date,
					Ga_prefix = item.Ga_prefix,
					Title = item.Title
				});
			}
		}

		public List<Models.JsonModels.TopDailysModel> QueryAllTopDailys()
		{
			var lists = new List<Models.JsonModels.TopDailysModel>();
			var dailys = DataBase.Table<TopDailysModel>().ToList();
			foreach (var item in dailys)
			{
				lists.Add(new Models.JsonModels.TopDailysModel()
				{
					Id = item.Id,
					Ga_prefix = item.Ga_prefix,
					Title = item.Title,
					Image = item.Image,
					Type = item.Type
				});
			}
			return lists;
		}

		public void DeleteAllTopDailys()
		{
			DataBase.DeleteAll<TopDailysModel>();
		}

		public void UpdateAllTopDailys(List<Models.JsonModels.TopDailysModel> lists)
		{
			foreach (var item in lists)
			{
				DataBase.InsertItem(new TopDailysModel
				{
					Id = item.Id,
					Ga_prefix = item.Ga_prefix,
					Title = item.Title,
					Image = item.Image,
					Type = item.Type
				});
			}
		}

		public Models.JsonModels.DailyModel QueryDaily(int id)
		{
			var vDaily = new Models.JsonModels.DailyModel();

			var daily = DataBase.Table<DailyModel>().Where(d => d.Id == id).FirstOrDefault();
			if (daily != null)
			{
				vDaily = new Models.JsonModels.DailyModel()
				{
					id = daily.Id,
					body = daily.body,
					ga_prefix = daily.ga_prefix,
					image = daily.image,
					image_source = daily.image_source,
					share_url = daily.share_url,
					title = daily.title,
					type = daily.type,
					updatetime = daily.updatetime,
					css = new List<string>(),
					js = new List<string>()
				};
				foreach (var item in DataBase.Table<DailyCssModel>().Where(d => d.DailyId == id).ToList())
				{
					vDaily.css.Add(item.css);
				}
				foreach (var item in DataBase.Table<DailyJsModel>().Where(d => d.DailyId == id).ToList())
				{
					vDaily.js.Add(item.js);
				}
			}
			return vDaily;
		}

		public void DeleteDaily(int id)
		{
			DataBase.DeleteItem<DailyModel>(id);
			foreach (var item in DataBase.Table<DailyJsModel>().Where(d => d.DailyId == id).ToList())
			{
				DataBase.DeleteItem<DailyJsModel>(item.Id);
			}
			foreach (var item in DataBase.Table<DailyCssModel>().Where(d => d.DailyId == id).ToList())
			{
				DataBase.DeleteItem<DailyCssModel>(item.Id);
			}
		}

		public void UpdateDaily(Models.JsonModels.DailyModel item)
		{
			DataBase.DeleteItem<DailyModel>(item.id);
			DataBase.InsertItem(new DailyModel
			{
				Id = item.id,
				body = item.body,
				ga_prefix = item.ga_prefix,
				image = item.image,
				image_source = item.image_source,
				share_url = item.share_url,
				title = item.title,
				type = item.type,
				updatetime = DateTime.Now
			});
			foreach (var js in DataBase.Table<DailyJsModel>().Where(d => d.DailyId == item.id).ToList())
			{
				DataBase.DeleteItem<DailyJsModel>(js.Id);
			}
			foreach (var js in item.js)
			{
				DataBase.InsertItem(new DailyJsModel
				{
					DailyId = item.id,
					js = js
				});
			}
			foreach (var css in DataBase.Table<DailyCssModel>().Where(d => d.DailyId == item.id).ToList())
			{
				DataBase.DeleteItem<DailyCssModel>(css.Id);
			}
			foreach (var css in item.css)
			{
				DataBase.InsertItem(new DailyCssModel
				{
					DailyId = item.id,
					css = css
				});
			}
		}

		public Models.JsonModels.DailyExtraModel QueryDailyExtra(int id)
		{
			var vExtra = new Models.JsonModels.DailyExtraModel();

			var extra = DataBase.Table<DailyExtraModel>().Where(d => d.Id == id).FirstOrDefault();
			if (extra != null)
			{
				vExtra = new Models.JsonModels.DailyExtraModel()
				{
					id = extra.Id,
					comments = extra.comments,
					long_comments = extra.long_comments,
					popularity = extra.popularity,
					short_comments = extra.short_comments
				};
			}
			return vExtra;
		}

		public void DeleteDailyExtra(int id)
		{
			DataBase.DeleteItem<DailyExtraModel>(id);
		}

		public void UpdateDailyExtra(Models.JsonModels.DailyExtraModel item)
		{
			DataBase.DeleteItem<DailyExtraModel>(item.id);
			DataBase.InsertItem(new DailyExtraModel
			{
				Id = item.id,
				comments = item.comments,
				long_comments = item.long_comments,
				popularity = item.popularity,
				short_comments = item.short_comments
			});
		}

		public Models.JsonModels.ArticleModel QueryArticle(int slug)
		{
			var vArticle = new Models.JsonModels.ArticleModel();

			var article = DataBase.Table<ArticleModel>().Where(d => d.Slug == slug).FirstOrDefault();
			if (article != null)
			{
				vArticle = new Models.JsonModels.ArticleModel()
				{
					Slug = article.Slug,
					CommentsCount = article.CommentsCount,
					Content = article.Content,
					LikesCount = article.LikesCount,
					PublishedTime = article.PublishedTime,
					Title = article.Title,
					TitleImage = article.TitleImage,
					Url = article.Url,
					UpdateTime = article.UpdateTime,
					Author = QueryAuthor(article.AuthorSlug)
				};
			}
			return vArticle;
		}

		public List<Models.JsonModels.ArticleModel> QueryArticles(int limit)
		{
			var vArticles = new List<Models.JsonModels.ArticleModel>();

			var articles = DataBase.Table<ArticleModel>().OrderByDescending(a => a.LikesCount).Skip(0).Take(limit).ToList();
			if (articles != null)
			{
				foreach (var article in articles)
				{
					vArticles.Add(new Models.JsonModels.ArticleModel()
					{
						Slug = article.Slug,
						CommentsCount = article.CommentsCount,
						Content = article.Content,
						LikesCount = article.LikesCount,
						PublishedTime = article.PublishedTime,
						Title = article.Title,
						TitleImage = article.TitleImage,
						Url = article.Url,
						UpdateTime = article.UpdateTime,
						Author = QueryAuthor(article.AuthorSlug)
					});
				}
			}
			return vArticles;
		}

		public void UpdateArticle(Models.JsonModels.ArticleModel item)
		{
			var author = item.Author;
			DataBase.DeleteItem<AvatarModel>(author.Slug);
			DataBase.InsertItem(new AvatarModel()
			{
				AuthorSlug = author.Slug,
				Id = author.Avatar.Id,
				Template = author.Avatar.Template,
			});
			DataBase.DeleteItem<AuthorModel>(author.Slug);
			DataBase.InsertItem(new AuthorModel()
			{
				Slug = author.Slug,
				Bio = author.Bio,
				Description = author.Description,
				Hash = author.Hash,
				IsOrg = author.IsOrg,
				Name = author.Name,
				ProfileUrl = author.ProfileUrl,
				Uid = author.Uid,
				Best_answererIdDescription = author.Badge != null ? author.Badge.Best_answerer.Description : null,
				IdentityDescription = author.Badge != null ? author.Badge.Identity.Description : null
			});
			DataBase.DeleteItem<ArticleModel>(item.Slug);
			DataBase.InsertItem(new ArticleModel()
			{
				CommentsCount = item.CommentsCount,
				Content = item.Content,
				LikesCount = item.LikesCount,
				PublishedTime = item.PublishedTime,
				Slug = item.Slug,
				Title = item.Title,
				TitleImage = item.TitleImage,
				Url = item.Url,
				AuthorSlug = item.Author.Slug,
				UpdateTime = item.UpdateTime
			});
		}

		public void UpdateArticles(List<Models.JsonModels.ArticleModel> lists)
		{
			foreach (var item in lists)
			{
				item.UpdateTime = DateTime.MinValue;
				UpdateArticle(item);
			}
		}

		public void DeleteArticle(int slug)
		{
			DataBase.DeleteItem<ArticleModel>(slug);
		}

		public Models.JsonModels.AuthorModel QueryAuthor(string slug)
		{
			var vAuthor = new Models.JsonModels.AuthorModel();

			var author = DataBase.Table<AuthorModel>().Where(d => d.Slug == slug).FirstOrDefault();
			if (author != null)
			{
				vAuthor = new Models.JsonModels.AuthorModel()
				{
					Bio = author.Bio,
					Slug = author.Slug,
					Description = author.Description,
					Hash = author.Hash,
					IsOrg = author.IsOrg,
					Name = author.Name,
					ProfileUrl = author.ProfileUrl,
					Uid = author.Uid,
					Avatar = QueryAvatar(author.Slug),
					Badge = new Models.JsonModels.IdentityModel()
					{
						Best_answerer = author.Best_answererIdDescription != null ? new Models.JsonModels.BestAnswererModel()
						{
							Description = author.Best_answererIdDescription,
							Topics = new List<int>()
						} : null,
						Identity = author.IdentityDescription != null ? new Models.JsonModels.BestAnswererModel()
						{
							Description = author.IdentityDescription,
							Topics = new List<int>()
						} : null
					}
				};
			}
			return vAuthor;
		}

		public void UpdateAuthor(Models.JsonModels.AuthorModel item)
		{
			DataBase.DeleteItem<AuthorModel>(item.Slug);
			DataBase.InsertItem(new AuthorModel
			{
				Slug = item.Slug,
				Bio = item.Bio,
				Description = item.Description,
				Hash = item.Hash,
				IsOrg = item.IsOrg,
				Name = item.Name,
				ProfileUrl = item.ProfileUrl,
				Uid = item.Uid,
				Best_answererIdDescription = item.Badge != null ? item.Badge.Best_answerer.Description : null,
				IdentityDescription = item.Badge != null ? item.Badge.Identity.Description : null
			});
			DataBase.DeleteItem<AvatarModel>(item.Slug);
			DataBase.InsertItem(new AvatarModel()
			{
				AuthorSlug = item.Slug,
				Id = item.Avatar.Id,
				Template = item.Avatar.Template,
			});

		}

		public Models.JsonModels.AvatarModel QueryAvatar(string slug)
		{
			var vAvatar = new Models.JsonModels.AvatarModel();

			var avatar = DataBase.Table<AvatarModel>().Where(d => d.AuthorSlug == slug).FirstOrDefault();
			if (avatar != null)
			{
				vAvatar = new Models.JsonModels.AvatarModel()
				{
					Id = avatar.Id,
					Template = avatar.Template
				};
			}
			return vAvatar;
		}

		public List<CollectionModel> QueryAllCollections()
		{
			return DataBase.Table<CollectionModel>().ToList();
		}

		public void DeleteAllCollections()
		{
			DataBase.DeleteAll<CollectionModel>();
		}

		public bool UpdateCollection(CollectionModel model)
		{
			try
			{
				DataBase.DeleteItem<CollectionModel>(model.IdOrSlug);
				DataBase.InsertItem(model);
				return true;
			}
			catch
			{
				return false;
			}

		}

		public bool JudgeExistCollection(int id)
		{
			var model = DataBase.Table<CollectionModel>().
				Where(d => d.IdOrSlug == id).FirstOrDefault();
			if (string.IsNullOrEmpty(model?.Title) == false)
				return true;
			return false;
		}

		public void DeleteCollection(int idOrSlug)
		{
			DataBase.DeleteItem<CollectionModel>(idOrSlug);
		}

	}
}
