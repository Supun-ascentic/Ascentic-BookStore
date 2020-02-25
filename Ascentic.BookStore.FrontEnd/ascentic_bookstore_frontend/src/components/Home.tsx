import * as React from 'react';
import { Link, RouteComponentProps,useHistory  } from 'react-router-dom';
import axios, { AxiosError } from 'axios';

import { Layout,Input,Select,Card,Row,Col, Button } from 'antd';
import "antd/dist/antd.css";
import "./Home.css";
import bookCoverPlaceholder from '../../public/book-cover-placeholder.jpg';

const InputGroup = Input.Group;
const { Option } = Select;
const { Meta } = Card;


const { Content ,Sider} = Layout;


interface IState {
    books: any[];
}



export default class Home extends React.Component<RouteComponentProps, IState> {

 

    constructor(props: RouteComponentProps) {
        super(props);
        this.state = { books: [] }
    }
    componentDidMount(): void {
        const config = {
          headers: { Authorization: `Bearer ${localStorage.getItem('AccessToken')}`}
        };
        
        axios.get(`https://localhost:44359/api/Book/get_books_with_all_Details`,config)
        .then(data => {
            this.setState({ books: data.data })
        }) 
        .catch(err=>{
          this.HandleError(err);
        })
    }
    deleteBook(id: number) {
        const config = {
          headers: { Authorization: `Bearer ${localStorage.getItem('AccessToken')}`}
        };
        axios.delete(`https://localhost:44359/api/Book/${id}`,config).then(data => {
            const index = this.state.books.findIndex(book => book.id === id);
            this.state.books.splice(index, 1);
            this.props.history.push('/');
        }).catch(err=>{
          this.HandleError(err);
        })
    }

    SortBooks(value:String){
      var bookGetUrl="https://localhost:44359/api/Book/get_books_with_all_Details";
      if(value==="Author"){
        bookGetUrl="https://localhost:44359/api/Book/get_books_sorted_by_author";
      }
      else if(value==="Title"){
        bookGetUrl="https://localhost:44359/api/Book/get_books_sorted_by_title";
      }

      const config = {
        headers: { Authorization: `Bearer ${localStorage.getItem('AccessToken')}`}
      };

      axios.get(bookGetUrl,config).then(data => {
            this.setState({ books: data.data });
      }).catch(err=>{
        this.HandleError(err);
      })
    }

    RedirectToLogin() {
      let path = `/login`;
      this.props.history.push("login");
    }

    HandleError(err:any){
      if(err.response.status==401){
        this.RedirectToLogin();
      }
      else{
        console.log(err)
      }
    }

    Logout(){
      localStorage.clear();
    }
  


    public render() {
        const books = this.state.books;
        return (
          <div>
            <div style={{background: '#fff', padding: 24,marginBottom:20, minHeight: 100 }}>
             
             
                <Layout className="layout" style={{backgroundColor: "white"}}>
                  <Content>
                      <div>
                          <InputGroup compact>
                            <b style={{paddingRight: 24}}>Sort By</b>
                            
                            <Select style={{minWidth: '20%'}} defaultValue="None" onChange={this.SortBooks.bind(this)}>
                              <Option value="None">None</Option>
                              <Option value="Author">Author</Option>
                              <Option value="Title">Title</Option>
                            </Select>
                          </InputGroup>
                        </div>
                  </Content>
                  <Sider style={{backgroundColor: "white",minWidth :300}}>
                    <div>
                      <Link to={`add-author`} ><Button type="primary">Add Author</Button></Link>
                      <Link to={`book-create`} ><Button type="primary">Add Book</Button></Link>
                      <Link to={`login`} ><Button type="danger" onClick={this.Logout}>Logout</Button></Link>
                    </div>
                  </Sider>
                </Layout>
                
               
                
            </div>
            <div style={{ background: '#fff', padding: 24}}>
             <Row gutter={[16, 16]} type="flex">
              {books && books.map(book =>
                <Col span={4} key={book.id} >
                  <Link to={`book-details/${book.id}`} >
                     <Card
                        hoverable
                        cover={<img className="BookListItem-img" alt="example" src={book.photoURL?book.photoURL:"/book-cover-placeholder.jpg"} />}
                        
                      >
                      <Meta title={book.title} />
                        <div style={{display: 'flex', paddingTop: 24 }}>
                          <b>Author :</b> 
                          {book.bookAuthor && book.bookAuthor.map((authorData: any) =>
                          <p style={{paddingLeft:5}} key={authorData.author.id}>{authorData.author.name}</p>
                          )}
                        </div>
                    
                      <h4 style={{ paddingTop: 8 }}>${book.price}</h4>
                    </Card>
                  </Link>
                </Col>
                
                )}
              </Row>
            </div>
          </div>
        )
    }
}