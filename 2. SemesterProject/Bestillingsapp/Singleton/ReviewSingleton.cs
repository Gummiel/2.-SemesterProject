﻿#region Directives

using System.Collections.ObjectModel;
using Bestillingsapp.Model;

#endregion

namespace Bestillingsapp.Singleton
{
    internal class ReviewSingleton
    {
        #region Instancefield

        private static ReviewSingleton _instance;

        #endregion

        #region Constructor

        private ReviewSingleton()
        {
        }

        #endregion

        #region Properties

        public static ReviewSingleton Instance => _instance ?? (_instance = new ReviewSingleton());

        public ObservableCollection<Review> Reviews = new ObservableCollection<Review>();

        #endregion
    }
}