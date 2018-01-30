using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QZhihuFind.Models.JsonModels
{
    public class AuthorModel
    {
        /// <summary>
        /// ����������ַ
        /// </summary>
        public string ProfileUrl { get; set; }
        /// <summary>
        /// ���˼��
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
        /// �Ƿ�����˺�
        /// </summary>
        public bool IsOrg { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// ���£�����֤��Ϣ
        /// </summary>
        public IdentityModel Badge { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ͷ��
        /// </summary>
        public AvatarModel Avatar { get; set; }
    }
}