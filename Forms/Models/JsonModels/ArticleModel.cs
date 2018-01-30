using System;

namespace QZhihuFind.Models.JsonModels
{
    public class ArticleModel
    {
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string PublishedTime { get; set; }
        /// <summary>
        /// ��ר���Ĵ�������Ϣ
        /// </summary>
        public AuthorModel Author { get; set; }
        /// <summary>
        /// ������ҳ���ݻ�ȡ
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// ���±���
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// ���±����ͼurl(��Ҫע�����,titleImage��ֵ�п���Ϊ��)����ͷ��һ����Ҳ������ϲ�ͬ�ĳߴ������ȡ��ͬ�ߴ��ͼƬ
        /// </summary>
        public string TitleImage { get; set; }
        /// <summary>
        /// HTML��ʽ�������������飬����ͨ��WebView����UIWebViewչʾ����
        /// </summary>
        public string Content { get; set; }
        public int Slug { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public int CommentsCount { get; set; }
        /// <summary>
        /// �޵�����
        /// </summary>
        public int LikesCount { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}