// Write your Javascript code.

var url = 'http://localhost:49866/api/news';

var app = new Vue({
  el: '#app',
  data: {
    message: 'News',
    news: [],
    showModal: false,
    oneNews: {}
  },
  created() {
    this.getData();
  },
  methods: {
    getData() {
      axios.get(url).then(response => {
        this.news = response.data;
        app.oneNews = response.data[0];
      });
    }
  }
});


Vue.component('modal', {
  template: '#modal-template'
});
