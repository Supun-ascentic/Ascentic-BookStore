import * as React from 'react';
import { Link, RouteComponentProps,useHistory  } from 'react-router-dom';
import axios from 'axios';

import { Table, Divider, Tag,Input,Select,Card,Row,Col } from 'antd';
import "antd/dist/antd.css";

import bookCoverPlaceholder from '../../public/book-cover-placeholder.jpg';

const InputGroup = Input.Group;
const { Option } = Select;
const { Meta } = Card;


const dataSource = ['Burns Bay Road', 'Downing Street', 'Wall Street'];

interface IState {
    books: any[];
}



export default class Home extends React.Component<RouteComponentProps, IState> {
    constructor(props: RouteComponentProps) {
        super(props);
        this.state = { books: [] }
    }
    componentDidMount(): void {
        axios.get(`https://localhost:44359/api/Book/get_books_with_all_Details`).then(data => {
            this.setState({ books: data.data })
        })
    }
    deleteBook(id: number) {
        axios.delete(`https://localhost:44359/api/Book/${id}`).then(data => {
            const index = this.state.books.findIndex(book => book.id === id);
            this.state.books.splice(index, 1);
            this.props.history.push('/');
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
      axios.get(bookGetUrl).then(data => {
            this.setState({ books: data.data });
      })
    }

    public OnBookClicked() {
      let path = `/details`;
      let history = useHistory();
      history.push(path);
    }
  


    public render() {
        const books = this.state.books;
        return (
          <div>
            <div style={{background: '#fff', padding: 24,marginBottom:20, minHeight: 100 }}>
                <InputGroup compact>
                  <b style={{paddingRight: 24}}>Sort By</b>
                  
                  <Select style={{minWidth: '20%'}} defaultValue="None" onChange={this.SortBooks.bind(this)}>
                    <Option value="None">None</Option>
                    <Option value="Author">Author</Option>
                    <Option value="Title">Title</Option>
                  </Select>
                </InputGroup>
            </div>
            <div style={{ background: '#fff', padding: 24, minHeight: 800 }}>
              <Row gutter={16}>
              {books && books.map(book =>
                <Col span={5} key={book.id}>
                  <Link to={`details/${book.id}`} >
                     <Card
                        bordered={false}
                        hoverable
                        style={{ width: 240,minHeight: 460,maxHeight: 500}}
                        cover={<img alt="example" src={book.photoURL?book.photoURL:"/book-cover-placeholder.jpg"} />}
                      >
                      <Meta title={book.title} />
                        <div style={{display: 'flex', paddingTop: 8 }}>
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