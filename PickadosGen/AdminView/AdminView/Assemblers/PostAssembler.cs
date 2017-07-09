using AdminView.Models;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminView.Assemblers
{
    public class PostAssembler
    {
        public static PostModel ConvertPostENtoModel(PostEN postEN)
        {
            PickCEN pickCEN = new PickCEN();
            TipsterCEN tipsterCEN = new TipsterCEN();

            PostModel postModel = new PostModel();

            postModel.Id = postEN.Id;
            postModel.Created_at = postEN.Created_at;
            postModel.Modified_at = postEN.Modified_at;
            postModel.Stake = postEN.Stake;
            postModel.Description = postEN.Description;
            postModel.Private_ = postEN.Private_;
            postModel.TotalOdd = postEN.TotalOdd;
            postModel.PostResult = postEN.PostResult;
            postModel.Likeit = postEN.Likeit;
            postModel.Report = postEN.Report;

            postModel.Tipster = UserAssembler.ConverterUserENtoModel(postEN.Tipster);
            postModel.Picks = PickAssembler.ConvertPickENtoModel(postEN.Pick);

            return postModel;
        }

        public static List<PostModel> ConvertPostENtoModel(IList<PostEN> posts)
        {
            List<PostModel> postsModel = new List<PostModel>();
            foreach (PostEN post in posts)
            {
                PostModel postModel = PostAssembler.ConvertPostENtoModel(post);
                postsModel.Add(postModel);
            }

            return postsModel;
        }
    }
}