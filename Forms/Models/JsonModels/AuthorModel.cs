using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QZhihuFind.Models.JsonModels
{
    public class AuthorModel
    {
        /// <summary>
        /// 个人资料网址
        /// </summary>
        public string ProfileUrl { get; set; }
        /// <summary>
        /// 个人简介
        /// </summary>
        public string Bio { get; set; }
        /// <summary>
        /// Hash
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// UID
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// 是否机构账号
        /// </summary>
        public bool IsOrg { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 徽章，即认证信息
        /// </summary>
        public IdentityModel Badge { get; set; }
        /// <summary>
        /// 个性域名
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public AvatarModel Avatar { get; set; }
    }
}