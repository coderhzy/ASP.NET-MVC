using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Web.Mvc.Html
{
    public static class HtmlExtensions
    {
    //扩展方法

        /// <summary>
        /// 单选列表
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="selectList"></param>
        /// <param name="htmlAttributes"></param>
        /// <param name="isHorizon"></param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper helper,
            string name,
            IEnumerable<SelectListItem> selectList,
            object htmlAttributes = null,
            bool isHorizon = true)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (SelectListItem selectItem in selectList)
            {
                //获取传入的htmlAttributes信息
                IDictionary<string, object> HtmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                //构建checkbox属性
                HtmlAttributes.Add("type", "radio");
                HtmlAttributes.Add("id", string.Format("{0}[{1}]", name, selectItem.Value));
                HtmlAttributes.Add("name", string.Format("{0}", name));
                HtmlAttributes.Add("class", "ruiCheckBox");
                HtmlAttributes.Add("value", selectItem.Value);
                if (selectItem.Selected)
                {
                    HtmlAttributes.Add("checked", "checked");
                }
                TagBuilder tagBuilder = new TagBuilder("input");
                tagBuilder.MergeAttributes<string, object>(HtmlAttributes);
                string inputAllHtml = tagBuilder.ToString(TagRenderMode.SelfClosing);
                string containerFormat = isHorizon ? @"<span>{0}{1}</span>&nbsp;&nbsp;" : @"<p><span>{0}{1}</span></p>";
                stringBuilder.AppendFormat(containerFormat, selectItem.Text, inputAllHtml);
            }
            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        /// <summary>
        /// 单选列表
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="selectList"></param>
        /// <param name="htmlAttributes"></param>
        /// <param name="isHorizon"></param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> selectList,
            object htmlAttributes = null,
            bool isHorizon = true)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string name = ExpressionHelper.GetExpressionText((LambdaExpression)expression);
            if (metadata.Model != null)
            {
                string value = metadata.Model.ToString();
                foreach (SelectListItem item in selectList)
                {
                    if (item.Value == value)
                        item.Selected = true;
                    else
                        item.Selected = false;
                }
            }
            return RadioButtonList(helper, name, selectList, htmlAttributes, isHorizon);
        }

        /// <summary>
        /// 复选列表
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name">标记名称</param>
        /// <param name="selectList">列表项</param>
        /// <param name="htmlAttributes">html属性</param>
        /// <param name="isHorizon">排列方式</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper helper,
            string name,
            IEnumerable<SelectListItem> selectList,
            object htmlAttributes = null,
            bool isHorizon = true)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (SelectListItem selectItem in selectList)
            {
                //获取传入的htmlAttributes信息
                IDictionary<string, object> HtmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                //构建checkbox属性
                HtmlAttributes.Add("type", "checkbox");
                HtmlAttributes.Add("id", string.Format("{0}[{1}]", name, selectItem.Value));
                HtmlAttributes.Add("name", string.Format("{0}", name));
                HtmlAttributes.Add("class", "ruiCheckBox");
                HtmlAttributes.Add("value", selectItem.Value);
                if (selectItem.Selected)
                {
                    HtmlAttributes.Add("checked", "checked");
                }
                TagBuilder tagBuilder = new TagBuilder("input");
                tagBuilder.MergeAttributes<string, object>(HtmlAttributes);
                string inputAllHtml = tagBuilder.ToString(TagRenderMode.SelfClosing);
                string containerFormat = isHorizon ? @"<span>{0}{1}</span>" : @"<p><span>{0}{1}</span></p>";
                stringBuilder.AppendFormat(containerFormat, selectItem.Text, inputAllHtml);
            }
            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        /// <summary>
        /// 复选列表
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="selectList"></param>
        /// <param name="htmlAttributes"></param>
        /// <param name="isHorizon"></param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> selectList,
            object htmlAttributes = null,
            bool isHorizon = true)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string name = ExpressionHelper.GetExpressionText((LambdaExpression)expression);
            if (metadata.Model != null)
            {
                string value = metadata.Model.ToString();
                List<string> list = (from a in value.Split(',')
                                     where a.Length > 0
                                     select a).ToList();
                foreach (SelectListItem item in selectList)
                {
                    if (list.Contains(item.Value))
                        item.Selected = true;
                    else
                        item.Selected = false;
                }
            }
            return CheckBoxList(helper, name, selectList, htmlAttributes, isHorizon);
        }
    }
}
